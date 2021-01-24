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
                var totalDays = (clockOutDate - clockInDate).TotalDays;
                if (totalDays < 2) continue;
                for (var x = 1; x < totalDays; x++)
                {
                    uniqueDays.Add(clockInDate.AddDays(x));
                }
            }
            return uniqueDays.Count;
        }
    }
