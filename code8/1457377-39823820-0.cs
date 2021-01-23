            try
              {
                var newList = data.GroupBy(o => o.Date).Where(o => o.Key <=                      Beginday).OrderByDescending(o => o.Key).Take(Y).SelectMany(o => o).GroupBy(x => new { x.Symbol })
                .Select
                (
                    x =>
                    {
                        var subList = x.OrderBy(y => y.Date).ToList();
                        return subList.Select((y, idx) =>
                        {
                            return new
                            {
                                Symbol = y.Symbol,
                                Close = y.Close,
                                Date = y.Date,
                                Vol = (idx < t - 1) ? 0 : new DescriptiveStatistics(subList.Skip(idx - t + 1).Take(t)
                                .Select(o =>
                                ((double)o.Close - (double)subList.Skip(idx - t + 1).First().Close) / (double)subList.Skip(idx - t + 1).First().Close).ToList()).StandardDeviation,                              
                        };
                        });
                    }
                )
                .SelectMany(x => x)
                .ToList();    
                }
         catch(Exception ex)
         {
         //your error
          }
