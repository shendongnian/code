    TimeZoneInfo westInfo =
        TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
    
    DateTime westTime = DateTime.Parse("2012.12.04T08:35:00");
    DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(westTime, westInfo);
