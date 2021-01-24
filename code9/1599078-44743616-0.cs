    public IEnumerable<TEntity> GetAll()
    {
        IQueryable<TEntity> obj = _repository.GetAll();
        PropertyInfo keyProperty = typeof(TEntity).GetProperty(string.Concat(typeof(TEntity).Name, "Id"));
        Expression parameter = Expression.Parameter(typeof(TEntity));
        Expression predicate = Expression.Lambda(Expression.Property(parameter, keyProperty), parameter);
        Expression queryExpression = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { typeof(TEntity), keyProperty.PropertyType }, obj, predicate);
        obj = obj.Provider.CreateQuery<TEntity>(queryExpression);
        return obj.Pagination();
    }
