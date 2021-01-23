	public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
	{
		IQueryable<TEntity> recordsToReturn = _dbSet.Where(criteria);
		
		if (OrderBy != null)
		{
			recordsToReturn = recordsToReturn.OrderByDescending(OrderBy);
		}
		if (ThenOrderBy != null)
		{
			recordsToReturn = recordsToReturn.ThenBy(ThenOrderBy);
		}
			
		return recordsToReturn.ToList();
	}
