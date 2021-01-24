    // Build list of weekdays
    List<DateTime> weekDays = new List<DateTime>();
    int days = (endDate - startDate).Days;
    for(int i = 0; i < days; i++)
    {
        DateTime date = startDate.AddDays(i);
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            continue;
        }
        weekDays.Add(date);
    }
    // Get the dates to be excluded
    IEnumerable<DateTime> excluded = earlyMod.Select(x => x.Date);
    // Get the absent dates
    IEnumerable<DateTime> absentDates = weekDays.Exclude(excluded);
