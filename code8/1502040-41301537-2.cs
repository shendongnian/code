	public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
	{
		IQueryable<TEntity> recordsToReturn = _dbSet.Where(criteria);
		
		if (OrderBy != null)
		{
			var orderedRecordsToReturn = recordsToReturn.OrderByDescending(OrderBy);
			recordsToReturn = orderedRecordsToReturn;
            // You can only call ThenBy() on an IOrderedQueryable
			if (ThenOrderBy == null)
			{
				recordsToReturn = orderedRecordsToReturn.ThenBy(ThenOrderBy);
			}
		}
			
		return recordsToReturn.ToList();
	}
