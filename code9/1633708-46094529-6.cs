    public async Task<string> GetValueAsync()
    {
        return "Cached Value";
    }
    public async Task Example1()
    {
        await this.GetValueAsync().ConfigureAwait(false);
    }
