    public virtual IQueryable<T> Query(bool eager = false)
    {
    	var query = _context.Set<T>().AsQueryable();
    	if (eager)
    	{
    		foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
    			query = query.Include(property.Name);
    	}
    	return query;
    }
    public virtual T Get(Guid itemId, bool eager = false)
    {
        return Query(eager).SingleOrDefault(i => i.EntityId == itemId);
    }
