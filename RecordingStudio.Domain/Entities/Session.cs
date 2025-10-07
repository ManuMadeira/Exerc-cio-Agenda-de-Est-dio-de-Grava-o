using System.Collections.ObjectModel;

namespace RecordingStudio.Domain
{
    public class Session
    {
        private readonly List<SessionParticipant> _participants = new();

        public int Id { get; }
        public StudioRoom Room { get; }
        public DateRange TimeRange { get; }
        public ReadOnlyCollection<SessionParticipant> Participants => _participants.AsReadOnly();

        public Session(int id, StudioRoom room, DateRange timeRange)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID deve ser um número positivo.");
                
            Id = id;
            Room = room ?? throw new ArgumentNullException(nameof(room), "A sala não pode ser nula.");
            TimeRange = timeRange ?? throw new ArgumentNullException(nameof(timeRange), "O período de tempo não pode ser nulo.");
        }

        public void AddParticipant(Musician musician, Instrument instrument, Role role, DateTime? arrivalTime = null)
        {
            if (musician == null)
                throw new ArgumentNullException(nameof(musician), "O músico não pode ser nulo.");

            if (_participants.Any(p => p.Musician == musician))
                throw new InvalidOperationException("Músico já é participante desta sessão.");

            var participant = new SessionParticipant(musician, instrument, role, arrivalTime);
            _participants.Add(participant);
        }

        public void EnsureHasAtLeastOneParticipant()
        {
            if (_participants.Count == 0)
                throw new InvalidOperationException("A sessão deve ter pelo menos um participante.");
        }
    }
}