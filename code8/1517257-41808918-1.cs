	IQueryable<Whatever> query = ...;
	
	if (searchText.StartsWith("^"))
	{
		query = query.Where(w => w.English.StartsWith(options.English.Substring(1)));
	}
	else
	{
		query = query.Where(w => w.English.Contains(options.English));
	}
	
