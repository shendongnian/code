    public static IQueryable<TSource> In<TSource, TMember>(
        this IQueryable<TSource> source,
        Expression<Func<TSource, TMember>> identifier, params TMember[] values)
    {
        // Some argument checks
        if (source == null)
        {
            throw new NullReferenceException(nameof(source));
        }
        if (identifier == null)
        {
            throw new NullReferenceException(nameof(identifier));
        }
        if (values == null)
        {
            throw new NullReferenceException(nameof(values));
        }
        // We only accept expressions of type x => x.Something
        // member wil be the x.Something
        var member = identifier.Body as MemberExpression;
        if (member == null)
        {
            throw new ArgumentException(nameof(identifier));
        }
        // Enumerable.Contains<TMember>(values, x.Something)
        var call = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), new[] { typeof(TMember) }, Expression.Constant(values), member);
        // x => Enumerable.Contains<TMember>(values, x.Something)
        var lambda = Expression.Lambda<Func<TSource, bool>>(call, identifier.Parameters);
        return source.Where(lambda);
    }
