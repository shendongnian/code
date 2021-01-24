    public async Task<string> Request(Method method, string url, string postData)
    {
        var handler = new System.Net.Http.HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };
        var http = new System.Net.Http.HttpClient(handler);
        System.Net.Http.HttpResponseMessage response;
        if (method == Method.POST)
        {
            var httpContent = new System.Net.Http.StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
            response = await http.PostAsync(new Uri(url), httpContent);
        }
        else
        {
            response = await http.GetAsync(new Uri(url));
        }
        return await response.Content.ReadAsStringAsync();
    }
