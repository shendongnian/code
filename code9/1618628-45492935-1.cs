    public static IEnumerable<DateTime> EnumerateFridays(DateTime fromIncl, DateTime toExcl)
    {
        fromIncl = fromIncl.Date; // just to be sure
        switch (fromIncl.DayOfWeek)
        {
            case DayOfWeek.Sunday: fromIncl = fromIncl.AddTicks(5 * TimeSpan.TicksPerDay); break;
            case DayOfWeek.Monday: fromIncl = fromIncl.AddTicks(4 * TimeSpan.TicksPerDay); break;
            case DayOfWeek.Tuesday: fromIncl = fromIncl.AddTicks(3 * TimeSpan.TicksPerDay); break;
            case DayOfWeek.Wednesday: fromIncl = fromIncl.AddTicks(2 * TimeSpan.TicksPerDay); break;
            case DayOfWeek.Thursday: fromIncl = fromIncl.AddTicks(TimeSpan.TicksPerDay); break;
            // case DayOfWeek.Friday: break;
            case DayOfWeek.Saturday: fromIncl = fromIncl.AddTicks(6 * TimeSpan.TicksPerDay); break;
        }
        Debug.Assert(fromIncl.DayOfWeek == DayOfWeek.Friday);
        for (; fromIncl < toExcl; fromIncl = fromIncl.AddTicks(7 * TimeSpan.TicksPerDay))
            yield return fromIncl;
    }
