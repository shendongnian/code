    public virtual IQueryable<TEntity> GetAllWithoutFilter(string[] include)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>().AsNoTracking().IgnoreQueryFilters();
    
        if (include != null)
        {
            query = include.Aggregate(query, (current, includePath) => current.Include(includePath));
        }
    
        return query;
    }
    public virtual IQueryable<TEntity> GetAll(string[] include)
    {
        IQueryable<TEntity> query =  Context.Set<TEntity>();
    
        if (include != null)
        {
            query = include.Aggregate(query, (current, includePath) => current.Include(includePath));
        }
    
        return query;
    }
