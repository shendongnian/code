    private static TimeSpan UnixTimeStampToDateTime(long unixTimeStamp)
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        dtDateTime = DateTime.FromMinutes((int)dtdateTime.TotalMinutes);
        return dtDateTime.TimeOfDay;
    }
