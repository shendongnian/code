    var result = dbSet
        .Where( <very complicated conditions> )
        .GroupBy(e => 1) // aribitrary value
        .Select(g => new
        {
            CountA = g.Count(),
            SumB = g.Sum(e => e.EntityB.PropertyB),
            AverageC = g.Average(e => e.EntityC.PropertyC),
        })
        .FirstOrDefault();
