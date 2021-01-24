    public static Expression<Func<TEntity, object>> GetSortExpression<TEntity>(string propertyName)
    {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Convert(Expression.Property(item, propertyName), typeof(object));
            var selector = Expression.Lambda<Func<TEntity, object>>(prop, item);
    
            return selector;
    }
