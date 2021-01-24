    public IList<T> Get(Expression<Func<T, bool>> filter)
    {
        List<T> list = null;
        IQueryable<T> dbQuery = _entities.Set<T>();
        dbQuery = dbQuery.Where(filter);
        list = dbQuery.ToList<T>();
        return list;
    }
