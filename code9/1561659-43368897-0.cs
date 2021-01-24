    public void Update<T>(IQueryable<T> query, Expression<Func<T, object>> orderBy = null)
    	where T : IEntity
    {
    	if (orderBy == null)
    		query = query.OrderBy(m => m.Id);
    	else
    		query = query.OrderBy(orderBy);
    }
