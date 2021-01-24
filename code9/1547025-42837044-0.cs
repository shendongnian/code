    public static dynamic ToDynamic<T>(this T obj)
    {
        IDictionary<string, object> expando = new ExpandoObject();
    
        foreach (var propertyInfo in typeof(T).GetProperties())
        {
            var propertyExpression = Expression.Property(Expression.Constant(obj), propertyInfo);
            var currentValue = Expression.Lambda<Func<string>>(propertyExpression).Compile().Invoke();
            expando.Add(propertyInfo.Name.ToLower(), currentValue);
        }
        return expando as ExpandoObject;
    }
