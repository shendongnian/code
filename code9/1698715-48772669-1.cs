    DateTime tp = DateTime.Now.ToUniversalTime();
    // offset value is in UTC
    DateTimeOffset offset = new DateTimeOffset(tp);
    DateTime utc = DateTime.UtcNow;
    
    Console.WriteLine(offset);
    Console.WriteLine(utc);
    CheckOffset(offset.DateTime);
    private static void CheckOffset(DateTimeOffset dateTime)
    {
        Console.WriteLine(dateTime.UtcDateTime.ToString("o", CultureInfo.InvariantCulture));
    }
