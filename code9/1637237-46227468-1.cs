    public static IEnumerable<Expression<Func<T, bool>>> Filter<T, TData>(
        this IEnumerable<TData> data,
        Expression<Func<T,TData, bool>> selector)
    {
        var parameter = selector.Parameters.First(p => p.Type.IsAssignableFrom(typeof(T)));
    
        return data.Select(item => Expression.Lambda<Func<T, bool>>(
            new DataVisitor<TData>(item).Visit(selector.Body), parameter));
    }
