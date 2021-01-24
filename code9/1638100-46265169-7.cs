    private static readonly AsyncLock _asyncLock = new AsyncLock();
    public async Task<string> Get(string value)
    {
        //Notice the use of using block
        //instead of try and finally 
        using(await _asyncLock.LockAsync())
        {
            return await CalculateSha256(value);
        }
    }
