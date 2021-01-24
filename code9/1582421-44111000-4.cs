    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dtDateTime;
    }
