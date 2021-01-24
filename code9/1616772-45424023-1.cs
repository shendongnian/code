    public virtual IQueryable<T> Listar(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,)
    {
        IQueryable<T> query = _dbset;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (orderBy != null)
        {
            return orderBy(query);
        }
        return query;
    }
