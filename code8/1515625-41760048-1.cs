    async Task<List<E1Entity>> GetE1Data()
    {
        using(var MyCtx = new MyCtx())
        {
             return await MyCtx.E1.Where(bla bla bla).ToListAsync();
        }
    }
    async Task<List<E2Entity>> GetE2Data()
    {
        using(var MyCtx = new MyCtx())
        {
             return await MyCtx.E2.Where(bla bla bla).ToListAsync();
        }
    }
    async Task DoSomething()
    {
        var t1 = GetE1Data();
        var t2 = GetE2Data();
        await Task.WhenAll(t1,t2);
        DoSomething(t1.Result, t2.Result);
    }
