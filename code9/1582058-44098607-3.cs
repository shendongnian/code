    private static Func<TQuery, TResult> GetMethod<TQuery, TResult>(object obj)
        where TQuery : IQuery<TResult> {
        // parameter
        var query = Expression.Parameter(typeof(TQuery), "query");
        // note Expression.Constant here - you use the same instance for every call
        var body = Expression.Call(Expression.Constant(obj), "Handle", new Type[0], query);
        return Expression.Lambda<Func<TQuery, TResult>>(body, query).Compile();
    }
