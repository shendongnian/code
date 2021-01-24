    public static DateTime FromTimeZoneToUtc(this DateTime dt, string timeZone)
    {
        var windowsId = TimeZoneConverter.TZConvert.IanaToWindows(timeZone);
        var tzi = TimeZoneInfo.FindSystemTimeZoneById(windowsId);
        return TimeZoneInfo.ConvertTimeFromUtc(dt, tzi);
    }
