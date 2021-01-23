    public async Task<string> SendWebRequest(string requestUrl)
    {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.GetAsync(requestUrl))
             return await response.Content.ReadAsStringAsync();
    }
