    //async methods where I'm confused with
    public async Task<string> GetStringAsync(int i)
    {
        return await Task.FromResult<string>(GetString(i));
    }
