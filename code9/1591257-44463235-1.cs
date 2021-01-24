    public static DateTime FromTimeZone(this DateTime dt, string timeZone)
    {
        var tz = DateTimeZoneProviders.Tzdb[timeZone];
        var local = LocalDateTime.FromDateTime(dt);
        return local.InZoneLeniently(tz).ToDateTimeUtc();
    }
