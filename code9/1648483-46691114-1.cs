    public static DateTime ConvertFromUTC(this DateTime date, TimeZoneInfo destZone)
    {
        var utcZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
        return TimeZoneInfo.ConvertTime(date, utcZone, destZone);
    }
