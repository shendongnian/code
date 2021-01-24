    public static IEnumerable<DateTime> GetDaysOfWeek(DateTime startDate, DayOfWeek desiredDayOfWeek)
    {
        var workingDate = new DateTime(startDate.Year, startDate.Month, 1);
        var offset = (int)desiredDayOfWeek - (int)workingDate.DayOfWeek + 7;
        var daysOfWeek = new List<DateTime>();
        do
        {
            // Jump to the first desired day of week.
            daysOfWeek.Add(workingDate.AddDays(offset));
            // Jump forward seven days to get the next desired day of week.
            workingDate = workingDate.AddDays(7);
        } while (workingDate.Month == startDate.Month);
        return daysOfWeek;
    }
