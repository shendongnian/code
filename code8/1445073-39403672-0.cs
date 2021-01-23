    public static DateTime[] WeekDaysFromWeekNo(int Year, int WeekNumber)
    {
        DateTime start = new DateTime(Year, 1, 1).AddDays(7 * WeekNumber);
        start = start.AddDays(-((int)start.DayOfWeek));
        return Enumerable.Range(1, 7).Select(num => start.AddDays(num)).ToArray();
    }
