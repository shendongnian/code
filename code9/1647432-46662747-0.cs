    var baseQueries = periodSlices
    	.Select(slice => db.Points
    		.Select(p => new { Period = new Period { Begin = slice.Begin, End = slice.End }, p.DT })
    		.Where(p => p.DT >= p.Period.Begin && p.DT <= p.Period.End)
    	);
    
    var unionQuery = baseQueries
    	.Aggregate(Queryable.Concat);
    
    var periodQuery = unionQuery
    	.GroupBy(p => p.Period)
    	.Select(g => new
    	{
    		Period = g.Key,
    		MinDT = g.Min(p => p.DT),
    		MaxDT = g.Max(p => p.DT),
    	});
    
    var finalQuery =
    	from p in periodQuery
    	join pMin in db.Points on p.MinDT equals pMin.DT
    	join pMax in db.Points on p.MaxDT equals pMax.DT
    	select new
    	{
    		Period = p.Period,
    		EarliestPoint = pMin,
    		LatestPoint = pMax,
    	};
    
