    var visitDays = from v in _dbContext.VisitorEvents
                    join e in _dbContext.VisitorEvents on v.VisitorId equals e.VisitorId
                    where e.EventId == eventId
                    group v by EntityFunctions.TruncateTime(v.VisitDay) into g
                    select new
                    {
                        Name = g.Key.ToString(),
                        Value = g.GroupBy(v => SqlFunctions.DatePart("HH", v.VisitDay))
                                 .Select(h => h.Key, Count = h.Count())
                    };
