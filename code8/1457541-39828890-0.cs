    var AccountLoggedOnEntries = log.Entries.Cast<EventLogEntry>()
        .Where(x => x.InstanceId == 4624)
        .GroupBy(x => x.DateGenerated)
        .Select(g => g.OrderBy(x => x.TimeGenerated).First())
        .Select(x => new {
            DateGenerated = x.TimeGenerated.ToShortDateString()
        ,   TimeGenerated = x.TimeGenerated.ToShortTimeString()
        ,   x.Message
        })
        .ToList();
