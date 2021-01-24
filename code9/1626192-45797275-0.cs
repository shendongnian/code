	var groupedResults = invoiced.Select(i => new Result
	{
		Title = i.Title,
		Invoiced = i.Amount
	}).Union(settled.Select(i => new Result
	{
		Title = i.Title,
		Settled = i.Amount
	})).Union(credit.Select(i => new Result
	{
		Title = i.Title,
		Credit = i.Amount
	}));
	var result = groupedResults
		.GroupBy(r => r.Title)
		.Select(g => new Result
		{
			Title = g.Key,
			Invoiced = g.Sum(r => r.Invoiced),
			Settled = g.Sum(r => r.Settled),
			Credit = g.Sum(r => r.Credit),
			SumAmount = g.Sum(r => r.Invoiced+r.Settled+r.Credit)
		});
