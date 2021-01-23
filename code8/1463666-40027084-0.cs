    public IEnumerable<TEntity> Fetch(Expression<Func<TEntity, bool>>  predicate, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy =null, int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }
