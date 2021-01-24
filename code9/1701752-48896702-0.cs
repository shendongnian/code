    public static class TimeSheetCalculations
    {
        public static int CalculateDistinctDays(this IEnumerable<TimeSheetEntry> entries)
        {
            var uniqueDays = new HashSet<DateTime>();
            foreach (var entry in entries)
            {
                var clockInDate = entry.ClockInTimeStamp.Date;
                var clockOutDate = entry.ClockOutTimeStamp.Date;
                uniqueDays.Add(clockInDate);
                uniqueDays.Add(clockOutDate);
                if ((clockOutDate - clockInDate).TotalDays > 1)
                {
                    for (var x = 1; x < (clockOutDate - clockInDate).TotalDays; x++)
                    {
                        uniqueDays.Add(clockInDate.AddDays(x));
                    }
                }
            }
            return uniqueDays.Count;
        }
    }
