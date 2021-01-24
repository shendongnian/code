    public async Task Func1Async(CancellationToken token)
    {
        foreach(var item in GetItems1())
        {
             await item.ProcessAsync(token);
             token.ThrowIfCancellationRequested();
        }
    }
