    public static class TimespanExtensions
    {
        public static TimeSpan TrimToMinutes(this TimeSpan input)
        {
            return TimeSpan.FromMinutes(Math.Truncate(input.TotalMinutes));
        }
    }
