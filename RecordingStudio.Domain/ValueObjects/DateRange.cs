using System;

namespace RecordingStudio.Domain
{
    public class DateRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentOutOfRangeException(nameof(start), "O início deve ser anterior ao fim.");

            Start = start;
            End = end;
        }

        public override bool Equals(object? obj)
        {
            return obj is DateRange other &&
                   Start == other.Start &&
                   End == other.End;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override string ToString()
        {
            return $"{Start:g} - {End:g}";
        }

        public static bool Overlaps(DateRange a, DateRange b)
        {
            return a.Start < b.End && b.Start < a.End;
        }
    }
}