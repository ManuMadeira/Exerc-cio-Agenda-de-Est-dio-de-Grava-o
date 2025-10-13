using System.Collections.ObjectModel;

namespace RecordingStudio.Domain
{
    public class StudioRoom
    {
        private readonly List<Session> _sessions = new();

        public int Id { get; }
        public string Name { get; }
        public ReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

        public StudioRoom(int id, string name)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID deve ser um número positivo.");
                
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome não pode estar vazio.", nameof(name));

            Id = id;
            Name = name.Trim();
        }

        public void Schedule(Session session)
        {
            if (session.Room != this)
                throw new InvalidOperationException("A sessão não pertence a esta sala.");

            // Ensure session has participants before scheduling
            session.EnsureHasAtLeastOneParticipant();

            if (_sessions.Any(s => DateRange.Overlaps(s.TimeRange, session.TimeRange)))
                throw new InvalidOperationException("A sessão sobrepõe com uma sessão existente na mesma sala.");

            _sessions.Add(session);
        }

        public void Cancel(int sessionId)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session != null)
                _sessions.Remove(session);
        }
    }
}