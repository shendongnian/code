    public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
    {
        IEnumerable<TEntity> query = _dbSet.Where(criteria);
        query = OrderDescending ? query.OrderByDescending(OrderBy) : query.OrderBy(OrderBy)
        if (paggedSearch)
        {            
            if(Skip > 0)
                query = query.Skip(Skip);
            if(Take > 0)
                query = query.Take(Take);
        }    
        return query.ToList();
    }
