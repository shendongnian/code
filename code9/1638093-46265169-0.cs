    public async Task<string> Get(string value)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            return await CalculateSha256(value);
        }
        finally
        { 
            _semaphoreSlim.Release();
        }
    }
