    public static bool IsInvalidTime(this DateTimeZone tz, LocalDateTime ldt)
    {
        return tz.MapLocal(ldt).Count == 0;
    }
    
    public static bool IsAmbiguousTime(this DateTimeZone tz, LocalDateTime ldt)
    {
        return tz.MapLocal(ldt).Count > 1;
    }
