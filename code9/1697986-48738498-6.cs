    var result = pageStatistics.Where(x => x.Status == 1)
                  .GroupBy(
                        x => new
                           {
                              CreatedAt = x.CreatedAt.Date,
                              x.AppID
                           })
                  .OrderByDescending(x => x.Key.CreatedAt)
                  .Select(
                        x => new
                           {
                              x.Key.CreatedAt,
                              Activity = x.Count()
                           })
                  .GroupBy(x => x.CreatedAt)
                  .Select(
                        x => new
                        {
                           Day = x.Key.ToString("dd/MM/yyyy"),
                           Activity = x.Sum(y => y.Activity),
                           RecordCount = x.Count()
                        })
                  .ToList();
