    public async Task Load<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        where TEntity : class
    {
        foreach (var propertyExpression in propertyExpressions)
        {
            var propertyName = propertyExpression.GetPropertyAccess().Name;
            await Entry(entity).Navigation(propertyName).LoadAsync();
        }
    }
