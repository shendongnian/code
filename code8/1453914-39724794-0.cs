    public async Task<string> SendWebRequest(string requestUrl)
    {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = client.GetAsync(requestUrl))
             return await response.Content.ReadAsStringAsync();
    }
