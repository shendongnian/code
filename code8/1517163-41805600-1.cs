    public static DateTime JumpToYear(this DateTime date, int year)
    {
        // you can also provide Hour, Minute, Second and Millisecond
        return new DateTime(year, date.Month, date.Day);
    }
