    public async Task<Entity> Func()
    {
        HttpContext.Current.Items.Add(key, value);
        
        await DBCalls.Method1Async();
        await DBCalls.Method2Async();
        
        var data = HttpContext.Current.Items[key];
        
        // rest of the method
    }
    
    async Task Method1Async()
    {
       await InternalMethod1().ConfigureAwait(false);
    }
    
    async Task Method2Async()
    {
       await InternalMethod2().ConfigureAwait(false);
    }
