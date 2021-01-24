    public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
    {
        var handlerType = 
            typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        dynamic handler = _context.Resolve(handlerType);
        return (TResult)await castedHandler.ExecuteAsync((dynamic)query);    
    }
