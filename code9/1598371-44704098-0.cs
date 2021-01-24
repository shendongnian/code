    public async Task<string> CreateAsync<T>(HttpClient client, string url, HttpMethod method, T data, Dictionary<string, string> parameters = null)
    {
        switch (method.Method)
        {
            case "POST":
                return await PostAsync(client, url, data);
            case "PUT":
                return await PutAsync(client, url, data);
            case "DELETE":
                return await DeleteAsync(client, url, parameters);
            default:
                return await GetAsync(client, url, parameters);
        }
    }
