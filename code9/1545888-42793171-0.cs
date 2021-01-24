    DateTime sourceTime = new DateTime(2015, 6, 10, 10, 20, 30, DateTimeKind.Unspecified);
    
    TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    
    foreach(var targetTimeZoneID in new string[] { "Pacific Standard Time", "Israel Standard Time", "Central European Standard Time" })
    {
        TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById(targetTimeZoneID);
        var converted = TimeZoneInfo.ConvertTime(sourceTime, sourceTimeZone, targetTimeZone);
    
        Console.WriteLine("{0}: {1:yyyy-MM-dd HH:mm:ss}", targetTimeZoneID, converted);
    }
    Console.ReadLine();
