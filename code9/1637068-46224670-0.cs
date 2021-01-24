    TimeZoneInfo origTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTimeOffset localDate = new DateTimeOffset(2017, 11, 14, 12, 0, 0, origTimeZone.BaseUtcOffset);
    Console.WriteLine(localDate); // 2017-11-14 12:00:00 (EST)
    TimeZoneInfo newTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
    DateTimeOffset test = TimeZoneInfo.ConvertTime(localDate, newTimeZone);
    Console.WriteLine(test); // 2017-11-14 19:00:00 (EGST)
    Console.WriteLine(test.ToUniversalTime()); // 2017-11-14 17:00:00 (UTC)
