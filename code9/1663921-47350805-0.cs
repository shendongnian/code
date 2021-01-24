	var c_comparisons = D_Collection.SelectMany(x => x.CIds.Select(y => new C { Id = y, Type = x.Type }));
	foreach (var comparison in c_comparisons)
	{
		var c = C_Collection.FirstOrDefault(x => x.Id == comparison.Id);
		if (c != null)
		{
			c.Type = comparison.Type;
		}
	}
