    DateTimeOffset timeIterator = new DateTimeOffset(new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Local));
    timeIterator = timeIterator.AddHours(1);
    timeIterator.LocalDateTime;
    // assuming you have a TimeZoneInfo object, you can also get different local times:
    TimeZoneInfo tzi = /* the timezone */;
    TimeZoneInfo.ConvertTimeFromUtc(timeIterator.UtcDateTime, tzi);
