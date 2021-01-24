    var start = DateTime.Parse("2017-02-01 11:00");
    var end = start.AddHours(1);
    var dailyUntilSummer = new RecurrencePattern(FrequencyType.Daily, 1)
    {
        Until = DateTime.Parse("2017-07-01 12:00"),
    };
    var calendarEvent = new Event
    {
        Start = new CalDateTime(start, "America/New_York"),
        End = new CalDateTime(end, "America/New_York"),
        RecurrenceRules = new List<IRecurrencePattern> { dailyUntilSummer },
    };
    
    var calendar = new Calendar();
    calendar.Events.Add(calendarEvent);
    
    var occurrences = calendar.GetOccurrences(start, start.AddMonths(6))
        .Select(o => new {Local = o.Period.StartTime, Utc = o.Period.StartTime.AsUtc})
        .OrderBy(o => o.Local)
        .ToList();
