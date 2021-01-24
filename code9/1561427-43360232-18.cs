    public string MyComplexMethod(params)
    {
            //Access db
            //Make WebRequests
            //...
    }
         
    public async Task MyComplexMethodAsync(params)
    {
        await Task.Run(() => MyComplexMethod()).ConfigureAwait(false);
    }
