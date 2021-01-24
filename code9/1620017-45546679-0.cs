    var timeZones = System.TimeZoneInfo.GetSystemTimeZones();
    foreach ( var timeZone in timeZones )
    {
        Console.WriteLine( "{0} - {1}", timeZone.Id,  timeZone.DisplayName );
    }
