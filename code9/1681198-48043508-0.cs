    private async Task<T> GetResponse<T>(Dictionary<string, object> args, string method)
    {
        try
        {
            using(var response = await _client.PostAsJsonAsync(method, args))
            {
                return await Deserialise<T>(response.Content); 
            }
        }
        catch (OperationCanceledException)
        {
            return default(T);
        }
    }
