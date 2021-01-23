    public string SendWebRequest(string requestUrl)
    {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = client.GetAsync(requestUrl).GetAwaiter().GetResult())
             return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }
