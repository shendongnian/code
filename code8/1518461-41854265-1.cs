	var res = data.Aggregate(new List<DataPerPeriod>(), (a, b) =>
	{
		if (b.First() =="Period")
		{
			a.Add(new DataPerPeriod { Name = String.Join("", b),
                                      Lines = new List<IEnumerable<string>>() });
		}
		else
        {
			a.Last().Lines.Add(b);
        }
		return a;
	});
