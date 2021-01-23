	public static T SingleOrDefaultWithErrorMessage<T>(this DbSet<T> entities, Func<T, Boolean> predicate = null, String entityName = "the record") where T : class
	{
		var entity = predicate != null
						? entities.SingleOrDefault(predicate)
						: entities.SingleOrDefault();
		if (entity != null)
			return entity;
		throw new ApplicationException($"Could not find {entityName}.");
	}
