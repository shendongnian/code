    public static IEnumerable<DateTime> GetDaysOfWeek(DateTime startDate, DayOfWeek desiredDayOfWeek)
    {
        var daysOfWeek = new List<DateTime>();
        var workingDate = new DateTime(startDate.Year, startDate.Month, 1);
        var offset = ((int)desiredDayOfWeek - (int)workingDate.DayOfWeek + 7) % 7;
        // Jump to the first desired day of week.
        workingDate = workingDate.AddDays(offset);
        do
        {
            daysOfWeek.Add(workingDate);
            // Jump forward seven days to get the next desired day of week.
            workingDate = workingDate.AddDays(7);
        } while (workingDate.Month == startDate.Month);
        return daysOfWeek;
    }
