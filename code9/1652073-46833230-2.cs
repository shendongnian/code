    static IEnumerable<DateTime> GetNonHolidays(DateTime start)
    {
        var holidays = GetHolidays(start);
        var current = start;
        foreach (var holiday in holidays)
        {
            // Yield everything until the next holiday
            while (current < holiday)
            {
                yield return current;
                current = current.AddDays(1);
            }
            // Skip this holiday, then look for the next one
            current = current.AddDays(1);
        }
        // No more holidays? Now we can just yield infinitely...
        while (true)
        {
            yield return current;
            current = current.AddDays(1);
        }
    }
