    static public void Prefetch<T>(this IQueryable<T> query)
    {
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        query.AsEnumerable().FirstOrDefault();
    }
