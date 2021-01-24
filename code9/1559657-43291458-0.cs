    public sealed class DateTimeRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public DateTimeRange(DateTime start, DateTime end)
        {
            // TODO: Validate that start <= end
            Start = start;
            End = end;
        }
        public bool Contains(DateTime value) => Start <= value && value < End;
    }
