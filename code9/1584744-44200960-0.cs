    public static IQueryable<T> IncludesAll<T>(this IQueryable<T> query,
    params Expression<Func<T, object>>[] includes)
    {
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
    
        return query;
    }
