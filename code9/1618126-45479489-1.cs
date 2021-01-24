    public static IQueryable<T> SelectExtend<T>(this IQueryable<T> source, IList<string> fields)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (fields == null) throw new ArgumentNullException(nameof(fields));
        var parameter = Expression.Parameter(typeof(T), "x");
        var body = Expression.MemberInit(
            Expression.New(typeof(T)),
            fields.Select(field => Expression.Bind(
                typeof(T).GetProperty(field),
                Expression.PropertyOrField(parameter, field))
            )
        );
        var selector = Expression.Lambda<Func<T, T>>(body, parameter);
        return source.Select(selector);
    }
