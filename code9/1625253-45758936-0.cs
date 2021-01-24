    public class DateTimeRange
    {
        private DateTime Start { get; set; }
        private DateTime End { get; set; }
        public DateTimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public int DayOffsCount()
        {
            var current = Start;
            var dayOffsCount = 0;
            while (current < End)
            {
                if (IsDayOff(current))
                {
                    dayOffsCount++;
                }
                current = current.AddDays(1);
            }
            return dayOffsCount;
        }
        
    }
     public bool IsDayOff(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                return true;
            return IsHoliday(dt);
        }
