    public static DateTime GetRealTimeInZone()
    {
        var clock = NetworkClock.Instance;
        var now = clock.GetCurrentInstant();
        var tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
        return now.InZone(tz).ToDateTimeUnspecified();
    }
