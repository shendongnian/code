    var AccountLoggedOnEntries = log.Entries.Cast<EventLogEntry>()
        .Where(x => x.InstanceId == 4624)
        .GroupBy(x => x.TimeGenerated.Date)
        .Select(x => new {
            DateGenerated = x.Key
            , TimeGenerated = x.Min(y => y.TimeGenerated).ToShortTimeString()
        })
        .ToList();
