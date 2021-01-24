    public async Task<TResult> TestGetAll<TResult>(string apiRoute, string json)
    {
        // For simplicity I've left out the using, but assume it in your code.
    
        var response = await client.PostAsJsonAsync(url, json);
    
        var resultString = await response.Content.ReadAsStringAsync();
    
        var result = JsonConvert.DeserializeObject<TResult>(resultString);
    
        return result;
    }
