    public static Expression<Func<TEntity, TKey>> GetSortExpression<TEntity, TKey>(string propertyName)
    {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, propertyName);
            var selector = Expression.Lambda<Func<TEntity, TKey>>(prop, item);
    
            return selector;
    }
