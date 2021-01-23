    var baseservices = list
    	.OrderBy(e => e.Date)
    	.Aggregate(new List<Quote>(), (r, e) =>
    	{
    		if (r.Count > 0 && r[r.Count - 1].Price == e.Price && r[r.Count - 1].PeriodEnd.AddDays(1) == e.Date)
    			r[r.Count - 1].PeriodEnd = e.Date;
    		else
    			r.Add(new Quote { Price = e.Price, PeriodStart = e.Date, PeriodEnd = e.Date });
    		return r;
    	});
