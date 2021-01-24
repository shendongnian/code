    public async Task<List<T>> GetList(string url)
    {
        var result = await url
                           .AppendPathSegments()
                           ...
    }
