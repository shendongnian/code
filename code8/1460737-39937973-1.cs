    private TEntity GeneralGet<TEntity>(int id) where TEntity : EntityBase
    {
    	using (var ctx = GetContext())
    	{
    		var result = ctx.Set<TEntity>().Where(e => e.Id == id);
    		if (result is IQueryable<IRevisionBase>)
    			result = WhereCurrentVersion((dynamic)result);
    		return result.FirstOrDefault();
    	}
    }
