    public Expression ConvertToLambda<T>(IQueryable<T> source, ParameterExpression param, MemberExpression parent, bool descending, bool anotherLevel)
    {
        var call = source.Expression;
        foreach (var s in _param)
        {
            var property = Expression.Property(parent, s);
            var mySortExpression = Expression.Lambda(property, param);
            call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                call,
                Expression.Quote(mySortExpression));
        }
        return call;
    }
    private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
    {
        // ...
        var call = sort.ConvertToLambda<T>(source, param, child as MemberExpression, descending, anotherLevel);
        // ...
    }
