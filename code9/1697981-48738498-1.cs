    var result = pageStatistics.Where(x => x.Status == 1)
               .GroupBy(
                  x => new
                     {
                        Day = x.CreatedAt.Date,
                        x.AppID
                     })
               .OrderByDescending(x => x.Key.Day)
               .Select(
                  x => new
                     {
                        Day = x.Key.Day.ToString("dd/MM/yyyy"),
                        AppID = x.Key.AppID,
                        RecordCount = x.Count()
                     })
               .ToList();
