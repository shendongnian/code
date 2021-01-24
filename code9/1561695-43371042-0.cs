	IQueryable<T> GenericSearch<T>(this IQueryable<T> items, string query)
	{
		var queryableProperties = items
			.First()
			.GetType()
			.GetProperties()
			.Where(p => p.PropertyType == typeof(string))
			.ToList();
	
		return items.Where(i => queryableProperties.Any(p => ((string)p.GetValue(i)).Contains(query)));
	}
