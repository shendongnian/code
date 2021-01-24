    public async Task<object> Post()
    {
        var kvs = await Request.Content.ReadAsFormDataAsync();
        return kvs.AllKeys.Select(k => new { key = k, value = kvs[k] });
    }
