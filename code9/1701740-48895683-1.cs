    private static Expression<Func<T, object>> ToLambda<T>(string propertyName) {
        var propertyNames = propertyName.Split('.');
        var parameter = Expression.Parameter(typeof(T));
        Expression body = parameter;
        foreach (var propName in propertyNames)
            body = Expression.Property(body, propName);
        return Expression.Lambda<Func<T, object>>(body, parameter);
    }
