    public IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> filter, params Expression<Func<TEntity,object>> includes)
    {
       var query = DbSet;
       foreach (var include in includes)
       {
          query = query.Include(include);
       }
       return query.Where(filter).ToList();
     }
