    var visitDays = from v in _dbContext.VisitorEvents
                         join e in _dbContext.VisitorEvents on v.VisitorId equals e.VisitorId
                         where e.EventId == eventId
                         group v by EntityFunctions.AddMicroseconds(v.VisitDay, -(int)v.VisitDay) into g
                         select new StatisticItemDto()
                         {
                             Name = g.Key.ToString(),
                             Value = g.Count()
                         };
         total =visitDays.Any()? visitDays.Sum(x => x.Value):0;
         foreach (var item in visitDays)
         {
             item.Percent = Framework.Utility.GetPercent(item.Value, total);
         }
