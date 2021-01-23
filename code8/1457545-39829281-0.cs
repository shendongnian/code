     var AccountLoggedOnEntries = log.Entries.Cast<EventLogEntry>()
                    .Where(x => x.InstanceId == 4624)
                    .GroupBy(x => x.TimeGenerated.Date)
                    .Select(days => days.OrderBy(time => time.TimeGenerated).FirstOrDefault())
                    .Select(x => new
                    {
                        DateGenerated = x.TimeGenerated.ToShortDateString()
                        ,
                        TimeGenerated = x.TimeGenerated.ToShortTimeString()
                        ,
                        x.Message
                    })
                    .ToList();
