    public static IQueryProvider<T> OrderByField<T>(this IQueryProvider<T> q, string SortField, bool Ascending)
    {
        var param = Expression.Parameter(typeof(T), "p");
        var prop = Expression.Property(param, SortField);
        string methodName = Ascending ? "OrderBy" : "OrderByDescending";
        Expression conversion = Expression.Convert(prop, typeof(object));
        LambdaExpression lambda = Expression.Lambda(conversion, param);
        object result = typeof(IQueryProvider<T>).GetMethods().Single(
                method => method.Name == methodName)
            .Invoke(q, new object[] { lambda });
        return (IQueryProvider<T>)result;
    }
