	public static T SingleOrDefaultWithErrorMessage<T>(this IEnumerable<T> entities, Func<T, Boolean> predicate = null, String entityName = null) where T : class
	{
		 if (predicate != null)
         {
                var entity = entities.SingleOrDefault(predicate);
                if (entity != null)
                    return entity;
         }
         else
         {
                var entity = entities.SingleOrDefault();
                if (entity != null)
                    return entity;
         }
        if (entityName == null)
            entityName = typeof(T).Name;
		throw new ApplicationException($"Could not find {entityName}.");
	}
