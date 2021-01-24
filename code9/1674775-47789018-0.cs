	var results =
		source
			.Skip(1)
			.Aggregate(
				source.Take(1).ToList(),
				(a, x) =>
				{
					if (x.timings.Subtract(a.Last().timings).TotalSeconds >= 5.0)
					{
						a.Add(x);
					}
					return a;
				});
