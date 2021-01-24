    public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T obj) {
        var json = JsonConvert.SerializeObject(obj); 
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return client.PostAsync(requestUri, content);    
    }
