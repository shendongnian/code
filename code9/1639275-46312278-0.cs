    public static double DateTimeToUTC(System.DateTime dateTime)
    {
        dateTime = System.DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        var utcValue = ((DateTimeOffset) dateTime).ToUnixTimeMilliseconds();
        return utcValue;
    }
