	public static T SingleOrDefaultWithErrorMessage<T>(this DbSet<T> entities, Func<T, Boolean> predicate, String entityName = "the record") where T : class
	{
		var entity = entities.SingleOrDefault(predicate);
		if (entity != null)
			return entity;
		throw new ApplicationException($"Could not find {entityName}.");
	}
