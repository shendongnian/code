    //async methods where I'm confused with
    public Task<string> GetStringAsync(int i)
    {
        return Task.FromResult<string>(GetString(i));
    }
