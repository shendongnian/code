    private static Int32 DifferenceInDays(ScheduleDays days)
    {
        if (days == ScheduleDays.None)
            return -1;
        Array values = Enum.GetValues(days.GetType());
        List<Int32> scheduled = new List<Int32>();
        foreach (ScheduleDays d in Enum.GetValues(days.GetType()).Cast<Enum>().Where(days.HasFlag))
        {
            if (d == ScheduleDays.None)
                continue;
            scheduled.Add(Array.IndexOf(values, d));
        }
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            return scheduled.OrderBy(x => x).First();
        return scheduled.Where(x => x > (Int32)DateTime.Now.DayOfWeek).First();
    }
