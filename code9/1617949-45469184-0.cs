	// Access Abcd
	using (var db = new AbcdEntities())
	{
		return db.Widgets.ToList();
	}
	
	// Access Efgh
	using (var db = new EfghEntities())
	{
		return db.Widgets.ToList();
	}
