    public string SendWebRequest(string requestUrl)
    {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = client.GetAsync(requestUrl))
             return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }
