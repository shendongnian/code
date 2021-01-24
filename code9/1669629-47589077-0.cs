    public async Task PostForm(Uri requestUri, string json)
    {
        using (var httpClient = new HttpClient())
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(requestUri, content);
        }
    }
