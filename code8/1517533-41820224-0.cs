    private DateTime ConvertToLocalTime(string datetimestring)
    {
        DateTime timeUtc = DateTime.Parse(datetimestring);
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        DateTimeOffset dateCst = new DateTimeOffset(timeUtc, cstZone.GetUtcOffset(timeUtc));
                
        return dateCst.DateTime;
    }
