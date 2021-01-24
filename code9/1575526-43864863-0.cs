    public static IQueryable<TEntity> FilterEntities<TEntity>(this IQueryable<TEntity> baseQuery, inputArray, value) // whatever their types are
    {
        var property = typeof(TEntity).GetProperty(inputArray[0], BindingFlags.Instance | BindingFlags.Public);
        var parameter = Expression.Parameter(typeof(TEntity));
        var memberExpression = Expression.Property(parameter, property);
        var eq = Expression.Equal(memberExpression, Expression.Constant(value));
        //Combining eq with ANDs and ORs
        var lambdaExpression = Expression.Lambda<Func<TEntity, bool>>(eq, parameter);
    
        return baseQuery.Where(lambdaExpression);
    }
