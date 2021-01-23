    public static DateTime JumtToYear(this DateTime date, int year)
    {
        return new DateTime(year, date.Month, date.Day,
           date.Hour, date.Minute, date.Second, date.Millisecond);
    }
