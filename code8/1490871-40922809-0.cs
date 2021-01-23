    public class TimeSpacCalculator
    {
        public static TimeSpan GetTimeSpanIntersect(TimeShift input, TimeSpan start, TimeSpan end)
        {
            // Loopsback from 23:59 - 00:00
            if (start > end)
                return GetTimeSpanIntersect(input, new TimeSpan(), end) +
                       GetTimeSpanIntersect(input, start, TimeSpan.FromHours(24));
            if (input.End < start)
                return new TimeSpan();
            if (input.Start > end)
                return new TimeSpan();
            var actualStart = input.Start < start
                ? start
                : input.Start;
            var actualEnd = input.End > end
                ? end
                : input.End;
            return actualEnd - actualStart;
        }
    }
