    public static Expression GreaterThanExpression<T>(string propertyName, object valueToCompare)
    {
        var entityType = typeof(T);
        var parameter = Expression.Parameter(entityType, "entity");
        var lambda = Expression.Lambda(
                Expression.GreaterThan(
                    Expression.Property(parameter, propertyName),
                    Expression.Constant(valueToCompare)
                )
            , parameter);
        return lambda;
    }
