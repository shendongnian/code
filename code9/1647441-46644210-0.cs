    public static DateTime GetISTDate()
    {
         DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now, TimeZoneInfo.Local);
         var ISTtime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.FindSystemTimeZoneById(Common.GetEnumDescription("India Standard Time")));
         return ISTtime;
    } 
