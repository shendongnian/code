    public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(
        this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonConvert.SerializeObject(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return await httpClient.PostAsync(url, content);
    }
