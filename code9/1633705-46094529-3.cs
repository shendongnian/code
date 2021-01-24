    public async Task<string> GetValueAsync()
    {
        return "Cached Value";
    }
    public async Task MyMethod()
    {
        await this.GetValueAsync().ConfigureAwait(false);
    }
