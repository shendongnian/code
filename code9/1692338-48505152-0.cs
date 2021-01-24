    // All purpose finder by predicate
	public static T Find<T>(this DemoContext instance, Expression<Func<T, bool>> predicate)
		where T : class, IEntity
	{
		var query = instance
			.Set<T>()
			.Where(predicate)
			.FirstOrDefault();
		return query;
	}
    // Specialize finder by predicate for marked entities
	public static T Find<T>(this DemoContext instance, Expression<Func<T, bool>> predicate, string value)
		where T : class, IMarker
	{
		var query = instance
			.Set<T>()
			.Where(p => p.SomeProp == value)
			.Where(predicate)
			.FirstOrDefault();
		return query;
	}
