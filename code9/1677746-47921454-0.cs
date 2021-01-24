    Console.WriteLine(string.Concat("DateTime.Now: ", DateTime.Now.TimeOfDay));
    Console.WriteLine(string.Concat("DateTime.UtcNow: ", DateTime.UtcNow.TimeOfDay));
    Console.WriteLine(string.Empty);
    string tziString = TimeZoneInfo.Local.Id;
    Console.WriteLine(string.Concat(tziString, ": ", 
        TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(tziString)).TimeOfDay));
    Console.WriteLine(string.Concat("UTC Offset: ", TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now)));
