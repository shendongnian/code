    var dotNetDateTime = new DateTime(2016, 1, 1, 12, 0, 0);
    var localDate = LocalDateTime.FromDateTime(dotNetDateTime);
    var chicagoTime = DateTimeZoneProviders.Tzdb["America/Chicago"];
    var chicagoZonedDateTime = chicagoTime.AtStrictly(localDate); // Will contain 2016 01 01 noon
    
    // now you can convert to time in Los Angeles
    var laTime = DateTimeZoneProviders.Tzdb["America/Los_Angeles"];
    var laZonedDateTime = chicagoZonedDateTime.WithZone(laTime); // will contain 2016 01 01 10am
         
