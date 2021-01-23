	var scores = new [] { 580, 560, 523, 523, 523, 520, 518, 518, 430, };
	
	var results =
		scores
			.OrderByDescending(x => x) // just in case scores not in order
			.GroupBy(x => x)
			.Aggregate(
				new { Rank = 1, Results = new List<Tuple<int, int>>() },
				(a, gx) =>
				{
					a.Results.AddRange(gx.Select(x => Tuple.Create(a.Rank, x)));
					return new { Rank = a.Rank + gx.Count(), Results = a.Results };
				})
			.Results;
