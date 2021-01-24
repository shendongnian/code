    public static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
    {
        string[] props = property.Split('.');
        Type type = typeof(T);
        ParameterExpression arg = Expression.Parameter(type, "x");
        Expression expr = arg;
        foreach (string prop in props)
        {
            PropertyInfo pi = type.GetProperty(prop);
            if (pi == null)
                pi = type.GetProperties().FirstOrDefault(x => x.Name.ToLower() == prop.ToLower());
            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;
        }
        Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
        LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
        object result = typeof(Queryable).GetMethods().Single(
            method => method.Name == methodName
            && method.IsGenericMethodDefinition
            && method.GetGenericArguments().Length == 2
            && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), type)
            .Invoke(null, new object[] { source, lambda });
        return (IOrderedQueryable<T>)result;
    }
    ApplyOrder(source, property, "OrderBy");
    ApplyOrder(source, property, "OrderByDescending")
    ApplyOrder(source, property, "ThenBy");
    ApplyOrder(source, property, "ThenByDescending");
