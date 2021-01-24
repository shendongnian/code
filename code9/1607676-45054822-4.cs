    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp);
        return dtDateTime; // still Utc Kind
    }
