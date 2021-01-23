    public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
    { 
         var result = _dbSet.Where(criteria).OrderByDescending(OrderBy);
         if(ThenOrderBy != null)
         {
            result = result.ThenBy(ThenOrderBy);
         }
         return result.ToList();
    }
