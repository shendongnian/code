            var ob = (from m in rawData
                      where m.Value.Keys.Any(i => i != ReportType.Sent)
                      group m by new { m.Key.Year, m.Key.Month, m.Value.Keys } into gx
                      select new
                      {
                          Date = new DateTime(gx.Key.Year, gx.Key.Month, 1),
                          //                          taa = gx.Key.Keys,
                          Total = gx.Select(m => m.Value.Values).ToList().Select(y => y.Sum()).FirstOrDefault()
                      }).ToList();
