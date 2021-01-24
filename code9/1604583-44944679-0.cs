    Each time you add new groupBy select inside groupby clause and press Ctrl + R + M and generate new method. you may pass this as a parameter.
    
    Do(Func<TSource, TKey>)
    
    var locationRevenues = revenues
                    .GroupBy(Func())
                    .Select(r => new
                    {
                        Location = r.Key,
                        RevenueTotal = r.Sum(i => i.RevenueAmount),
    
                    })
                    .ToList();
    
    
    private static Func<Revenues, object> Func()
            {
                return g => new { Location = g.Location, Month = 9 };
            }
