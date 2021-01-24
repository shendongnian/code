    public static T Next<T>(T currentElement, params Expression<Func<T, object>>[] includes)
        where T : class, IModel
    {
    	if (currentElement.Id >= GetLastId<T>())
    		return currentElement;
    
    	using (DatabaseEntities context = new DatabaseEntities())
    	{
    		IQueryable<T> query = context.Set<T>();
    
            //Deferred execution allows us to build up the query
    		foreach (var include in includes)
    		{
    			query = query.Include(include);
    		}
    		
    		return query.Single(el => el.Id == currentElement.Id + 1);
    	}
    }
