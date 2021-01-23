    private TEntity GeneralGet<TEntity>(int id) where TEntity : EntityBase
    {
    	using (var ctx = GetContext())
    	{
    		var result = ctx.Set<TEntity>().Where(e => e.Id == id);
    		if (result is IQueryable<IRevisionBase>)
    		{
    			var parameter = Expression.Parameter(typeof(TEntity), "e");
    			var predicate = Expression.Lambda<Func<TEntity, bool>>(
    				Expression.Property(parameter, nameof(IRevisionBase.CurrentVersion)),
    				parameter);
    			result = result.Where(predicate);
    		}
    		return result.FirstOrDefault();
    	}
    }
