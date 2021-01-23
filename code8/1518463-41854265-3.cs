	var res = data.Aggregate(new List<DataPerPeriod>(), (a, b) =>
	{
		if (b.First() =="Period")
		{
			a.Add(new DataPerPeriod { Name = b, Lines = new List<IEnumerable<string>>() });
		}
		else
        {
			a.Last().Lines.Add(b);
        }
		return a;
	})
	.ToDictionary(x=>x.Name, x=>x.Lines);
