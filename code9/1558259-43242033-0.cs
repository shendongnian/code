    // Only need to do this once...
    private static readonly TimeZoneInfo londonZone =
        TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
    public static DateTime GetLocalDateTimeNow() =>
        TimeZoneInfo.ConvertTime(DateTime.UtcNow, londonZone);
