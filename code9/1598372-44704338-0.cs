    public async Task<string> CreateAsync<T>(HttpClient client, string url, HttpMethod method, T data, Dictionary<string, string> parameters = null)
    {
        switch (method)
        {
            case HttpMethod m when m == HttpMethod.Post:
                return await PostAsync(client, url, data);
            case HttpMethod m when m == HttpMethod.Put:
                return await PutAsync(client, url, data);
            case HttpMethod m when m == HttpMethod.Delete:
                return await DeleteAsync(client, url, parameters);
            default:
                return await GetAsync(client, url, parameters);
        }
    }
