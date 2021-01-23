    public static int ConvertFromTimeZoneToMinutesOffset(string timeZone, IClock clock)
    {
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZone];
        Offset offset = zone.GetUtcOffset(clock.Now);
        return offset.Ticks / NodaConstant.TicksPerMinute;
    }
