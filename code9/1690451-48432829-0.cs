    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
    {
        var query = _ctx.Set<T>().AsQueryable();
        return includes.Aggregate(query, (q, w) => q.Include(w));
    }
