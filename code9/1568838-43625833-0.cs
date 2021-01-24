    public static double DateTimeToUnixTimestamp(DateTime dateTime)
    {
        return (TimeZoneInfo.ConvertTimeToUtc(dateTime) - 
               new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
    }
