    public async Task<int> DoSomethingAsync(Func<Task<int>> action)
    {
    	return await Task.FromResult<int>(3);
    }
    
    public async Task<int> MethodOneAsync()
    {
    	await Task.Delay(10);
    	return await DoSomethingAsync(async () => await Task.FromResult<int>(3));
    }
    
    public async Task<int> MethodOneAsync()
    {
    	await Task.Delay(10);
    	return await DoSomethingAsync(() => Task.FromResult<int>(3));
    }
