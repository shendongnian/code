    private static DateTimeOffset ConvertToLocalTime(string datetimestring)
    {
        DateTime timeUtc = DateTime.Parse(datetimestring, null, DateTimeStyles.AdjustToUniversal);
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        DateTimeOffset dateCst = new DateTimeOffset(timeUtc, cstZone.GetUtcOffset(timeUtc));
    
        return dateCst;
    }
