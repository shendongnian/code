	var filtered =
		pairs.Skip(1).Aggregate(pairs.Take(1).ToList(), (a, p) =>
		{
			if (p.Key.Subtract(a.Last().Key).TotalMinutes >= 1.0)
			{
				a.Add(p);
			}
			return a;
		}).ToList();
