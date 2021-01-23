    static Func<IList<T>, string> GenerateStrExpressionCached<T>(string propName)
    {
        var oParameter = Expression.Parameter(typeof(T), "o");
        var propertyExpression = Expression.PropertyOrField(oParameter, propName);
        var cast = Expression.Convert(propertyExpression, typeof(object));
        var lambda = Expression.Lambda<Func<T, object>>(cast, oParameter).Compile();
        // here we return a lambda to operate against the list.
        return list => string.Concat(list.Select(lambda));
    }
