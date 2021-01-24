    // The source time in UTC
    DateTimeOffset utc = new DateTimeOffset(2017, 9, 11, 0, 0, 0, TimeSpan.Zero);
    // The time zone for the Eastern US
    TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    // The converted time in the time zone
    DateTimeOffset eastern = TimeZoneInfo.ConvertTime(utc, timeZone);
    // output in a usable format
    Console.WriteLine(eastern.ToString("yyyy-MM-dd HH:mm:ss zzz"));
    //=>  2017-09-10 20:00:00 -04:00
