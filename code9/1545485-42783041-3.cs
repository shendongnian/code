    public virtual TEntity FindBy<TFetched>(Expression<Func<TEntity, bool>> query,
        Expression<Func<TEntity, TFetched>> fetch)
    {
        var query = NHUnitOfWork.Session.Query<TEntity>().Where(query);
        if (fetch != null)
            query = query.Fetch(fetch);
        return query
            .FirstOrDefault();
    }
