    // Parse input as LocalDateTime values (since they represent a local date and time)
    var pattern = LocalDateTimePattern.CreateWithInvariantCulture("yyyy-MM-dd HH:mm:ss");
    LocalDateTime ldt1 = pattern.Parse("2017-03-26 00:00:00").Value;
    LocalDateTime ldt2 = pattern.Parse("2017-03-26 03:00:00").Value;
    // Apply a specific time zone, now making them ZonedDateTime values
    // Using "lenient" conversions allows for default handling of ambiguous/invalid values
    DateTimeZone tz = DateTimeZoneProviders.Tzdb["Europe/London"];
    ZonedDateTime zdt1 = ldt1.InZoneLeniently(tz);
    ZonedDateTime zdt2 = ldt2.InZoneLeniently(tz);
    // Now simply determine the elapsed duration between these
    Duration result = zdt2 - zdt1;
