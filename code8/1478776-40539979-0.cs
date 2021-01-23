    public async static Task Execute<TResult>(Func<TResult> method) where TResult : class
    {
        var result = method();
        if (typeof(TResult).IsGenericType
            && typeof(TResult).GetGenericTypeDefinition() == typeof(Task<>))
        {
            var taskResult = await (dynamic)result;
            StoreResult(taskResult);
        }
        else
        {
            StoreResult(result);
        }
    }
