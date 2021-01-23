    // Transform the "time" in a localized time.                
    var tzLocalTime = LocalDateTime.FromDateTime(time);
    try
    {
        // To get the exact same time in the specified zone.
        zoned = tzLocalTime.InZoneStrictly(zone);
    }
    catch(SkippedTimeException)
    {
        // This happens if the time is skipped
        // because of daylight saving time.
        //
        // Example:
        // If DST starts at Oct 16 00:00:00,
        // then the clock is advanced by 1 hour
        // which means Oct 16 00:00:00 is *skipped*
        // to Oct 16 01:00:00.
        // In this case, it is not possible to convert
        // to exact same date, and SkippedTImeException
        // is thrown.
        // InZoneLeniently will convert the time
        // to the start of the zone interval after
        // the skipped date.
        // For the example above, this would return Oct 16 01:00:00.
         // If someone schedules an appointment at a time that
         // will not occur, than it is ok to adjust it to what
         // will really happen in the real world.
         
         var originalTime = ste.LocalDateTime;
         // Correct for the minutes, seconds, and milliseconds.
         // This is needed because if someone schedueld an appointment
         // as 00:30:00 when 00:00:00 is skipped, we expect the minute information
         // to be as expected: 01:30:00, instead of 01:00:00.
         var minuteSecondMillisecond = Duration.FromMinutes(originalTime.Minute) + Duration.FromSeconds(originalTime.Second) + Duration.FromMilliseconds(originalTime.Millisecond);
         zoned = zLocalTime.InZoneLeniently(zone).Plus(minuteSecondMillisecond);
    }
    catch(AmbiguousTimeException ate)
    {
        // This happens when the time is ambiguous.
        // During daylight saving time, for example,
        // an hour might happen twice.
        //
        // Example:
        // If DST ends on Feb 19 00:00:00, then
        // Feb 18 23:00:00 will happen twice:
        // once during DST, and once when DST ends
        // and the clock is set back.
        // In such case, we assume the earlier mapping.
        // We could work with the second time that time
        // occur with ate.LaterMapping.
        zoned = ate.EarlierMapping;
    }
