    private static Func<object, TQuery, TResult> GetMethod<TQuery, TResult>()
        where TQuery : IQuery<TResult> {
        // "query" paramter
        var query = Expression.Parameter(typeof(TQuery), "query");
        // "handler" parameter
        var handler = Expression.Parameter(typeof(object), "handler");
        // convert your "object" parameter to handler type (not type safe of course)
        // ((IQueryHandler<TQuery, TResult>) handler).Handle(query)
        var body = Expression.Call(Expression.Convert(handler, typeof(IQueryHandler<TQuery, TResult>)), "Handle", new Type[0], query);
        //(handler, query) => ((IQueryHandler<TQuery, TResult>) handler).Handle(query);
        return Expression.Lambda<Func<object, TQuery, TResult>>(body, handler, query).Compile();
    }
    object handler = new MyQueryHandler();
    var func = GetMethod<MyQuery, int>();
    var result = func(handler, query);
