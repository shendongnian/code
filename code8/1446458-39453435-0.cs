	IEnumerable<Entity> Get()
	{
		var ids = new[] { 1, 2, 3 };
		if (ids.Length == 0) return Enumerable.Empty<Entity>();
		
		return MyContext.MyEntities.Where(x=>ids.Contains(x.Id)).ToArray();
	}
