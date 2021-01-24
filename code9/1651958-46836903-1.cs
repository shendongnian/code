    public static DateTime GetRealTimeInZone(string timeZoneId)
    {
        var clock = NetworkClock.Instance;
        var now = clock.GetCurrentInstant();
        var tz = DateTimeZoneProviders.Tzdb[timeZoneId];
        return now.InZone(tz).ToDateTimeUnspecified();
    }
