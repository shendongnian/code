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
