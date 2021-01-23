    var baseservices = list
            .GroupBy(l => l.Price)
            .Select(g => new
            {
                Price = g.Key,
                Dates = Convert(g.Select(d=>d.Date)).ToList()
            })
           .SelectMany(r=>r.Dates, (a,b)=>new Quote {
                                  Price = a.Price, 
                                  PeriodStart = b.PeriodStart, 
                                  PeriodEnd = b.PeriodEnd})
           .ToList();
