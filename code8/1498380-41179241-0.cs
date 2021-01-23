    public virtual TEntity GetById(object id,
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = GetActive();
    
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties.Length > 0)
            {
                query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            else
            {
                return DbSet.Find(id);
            }
    
            if (query.Any())
            {
                return query.First();
            }
            return query.First();
        }
    public IQueryable<TEntity> GetActive()
    {
        return 
            DbSet.Where(a => a.Active);
    }
