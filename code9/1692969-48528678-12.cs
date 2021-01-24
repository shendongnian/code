    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public DateTime Start { get; }
        public DateTime End { get; }
        public Period Intersect(Period other)
        {
            long start = Math.Max(Start.Ticks, other.Start.Ticks);
            long end = Math.Min(End.Ticks, other.End.Ticks);
            if (start > end) { // Periods not intersecting.
                return null;
            }
            return new Period(new DateTime(start), new DateTime(end));
        }
        public Period Union(Period other)
        {
            if (other.Start > End || other.End < Start) {
                // Periods not overlapping nor touching.
                return null;
            }
            return new Period(
                new DateTime(Math.Min(Start.Ticks, other.Start.Ticks)),
                new DateTime(Math.Max(End.Ticks, other.End.Ticks))
            );
        }
    }
