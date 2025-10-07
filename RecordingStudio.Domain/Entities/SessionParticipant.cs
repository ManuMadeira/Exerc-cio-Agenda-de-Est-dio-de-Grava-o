namespace RecordingStudio.Domain
{
    public class SessionParticipant
    {
        public Musician Musician { get; }
        public Instrument Instrument { get; }
        public Role Role { get; }
        public DateTime? ArrivalTime { get; }

        internal SessionParticipant(Musician musician, Instrument instrument, Role role, DateTime? arrivalTime)
        {
            Musician = musician ?? throw new ArgumentNullException(nameof(musician));
            Instrument = instrument;
            Role = role;
            ArrivalTime = arrivalTime;
        }
    }
}