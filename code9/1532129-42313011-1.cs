    public IQueryable<TEntity> Filter(
       IQueryable<TEntity> filteredEntityCollection, TProperty value)
    {
        var param = Expression.Parameter(typeof(TEntity), "p");
        var lambda = Expression.Lambda<Func<TEntity, bool>>(                
            Expression.Equal(
                Expression.Property(param, propertyInfo),
                Expression.Constant(value)
            ), param);
        return filteredEntityCollection.Where(lambda);
    }
