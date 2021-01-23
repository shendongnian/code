    ReadOnlyCollection<TimeZoneInfo> tzCollection;
    tzCollection = TimeZoneInfo.GetSystemTimeZones();
    Console.WriteLine(tzCollection.Count);
    foreach (TimeZoneInfo timeZone in tzCollection)
    {
        Console.WriteLine("{0} : {1} : {2}", timeZone.Id, timeZone.DisplayName, timeZone.BaseUtcOffset.TotalMinutes);
    }
