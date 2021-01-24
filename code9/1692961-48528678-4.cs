    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public  DateTime Start { get; }
        public DateTime End { get; }
        public bool OverlapsOrTouches(Period other)
        {
            return other.Start <= End && other.End >= Start;
        }
    }
