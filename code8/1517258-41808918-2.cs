	IQueryable<Whatever> query = ...;
	
	if (searchText.StartsWith("^"))
	{
		query = query.Where(w => w.English.StartsWith(searchText.Substring(1)));
	}
	else
	{
		query = query.Where(w => w.English.Contains(searchText));
	}
	
