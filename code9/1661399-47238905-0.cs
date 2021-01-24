    ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
    
    foreach (TimeZoneInfo timeZone in timeZones)
    {
        if (timeZone.StandardName.Contains("Tahiti"))
        {
            //You have got the timezone
            break;
        }
    }
