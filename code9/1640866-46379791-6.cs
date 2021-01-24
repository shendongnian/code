    public Expression<Func<object, object>> MapValue(string name, Type sourceType)
    {
        var parameter = Expression.Parameter(typeof(object));
        var objectParameter = Expression.Convert(parameter, sourceType);
        var property = Expression.PropertyOrField(objectParameter, name);
        var propertyConverted = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<object, object>>(propertyConverted, parameter);
    }
