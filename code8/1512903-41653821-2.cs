    var baseservices = list
            .GroupBy(l => l.Price)
            .Select(g => new
            {
                Price = g.Key,
                Dates = Convert(g.Select(d=>d.Date)).ToList()
            });
