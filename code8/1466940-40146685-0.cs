    var localZone = DateTimeZone.ForOffset(Offset.FromHours(7));
    var start = Instant.FromDateTimeOffset(new DateTimeOffset(new DateTime(2016, 10, 1)));
    var end = Instant.FromDateTimeOffset(new DateTimeOffset(new DateTime(2016, 10, 25)));
    var interval = new Interval(start, end);
    var l = Enumerable.Range(0, int.MaxValue)
            .Select(x => Period.FromDays(x))
            .Select(x => LocalDate.Add(interval.Start.InZone(localZone).Date, x))
            .TakeWhile(x => x.CompareTo(interval.End.InZone(localZone).Date) <= 0);
    foreach (var localDate in l)
    {
        Console.WriteLine(localDate);
    }
