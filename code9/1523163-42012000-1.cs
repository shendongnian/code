    List<WashTime> thisWeek = times.Where(
        time => HelperFunctions.GetIso8601WeekOfYear(time.Time) == HelperFunctions.GetIso8601WeekOfYear(DateTime.Today)
    ).OrderBy(f => f.Time.DayOfWeek).ThenBy(f => f.Time.Hour).ThenBy(f.Machine
    ).GroupBy(
        f=> new { f.Time.DayOfWeek, f.Time.Hour, f.Machine}
    ).Select(
        group => group.First()
    ).ToList()
