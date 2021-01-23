    public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
    {
        var query = _dbSet.Where(criteria);
        if(OrderBy != null)
        {
            query = query.OrderByDescending(OrderBy);
        }
        if(ThenOrderBy != null)
        {
            query = query.ThenBy(ThenOrderBy);
        }
        return query.ToList();
    }
