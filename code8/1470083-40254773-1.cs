    static string GenerateStrExpression<T>(IList<T> obj, string propName)
    {
        // o
        var oParameter = Expression.Parameter(typeof(T), "o");
        // o.Property
        var propertyExpression = Expression.PropertyOrField(oParameter, propName);
        // cast to object ensure we don't get compiler errors when creating the lambda
        var cast = Expression.Convert(propertyExpression, typeof(object));
        // o => (object)o.Property;
        var lambda = Expression.Lambda<Func<T, object>>(cast, oParameter).Compile();
    
        return string.Concat(obj.Select(lambda));
    }
