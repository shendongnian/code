    // See - https://stackoverflow.com/a/7908482/1603275 for a fuller list of options
    TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
    
    // Not sure if DateTime.UtcNow will default to DateTimeKind.Utc
    DateTime utcDate = DateTime.UtcNow;
    utcDate = DateTime.SpecifyKind(utcDate, DateTimeKind.Utc);
    
    DateTime localDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, sourceTimeZone);
    Console.WriteLine(localDate);
