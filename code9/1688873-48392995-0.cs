    public static DateTime ParseTimestampToPSTDateTime(long timestamp)
    {
        TZ4Net.OlsonTimeZone pst = TZ4Net.OlsonTimeZone.GetInstanceFromOlsonName("America/Los_Angeles");
        
        return pst.ToLocalTime(ParseTimestampToDateTime(timestamp));
    }
