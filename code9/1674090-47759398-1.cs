    public sealed override void OnInvoke(MethodInterceptionArgs args)
    {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        var result = cache.StringGet(args.Method.Name); // retrieving from Redis
    
        if (result.HasValue)
        {
            args.ReturnValue = Deserialize(result);
            return;
        }
    
        base.OnInvoke(args);
        cache.StringSet(args.Method.Name, Serialize(args.ReturnValue));
    }
