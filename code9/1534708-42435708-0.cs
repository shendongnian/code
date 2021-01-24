    public static async Task<string> getForwardUrl(string url)
    {
        var handler = new System.Net.Http.HttpClientHandler();
        handler.AllowAutoRedirect = false;
        var client = new System.Net.Http.HttpClient(handler);
    
        var response = await client.GetAsync(url);
    
        if (response.StatusCode == System.Net.HttpStatusCode.Redirect || response.StatusCode == System.Net.HttpStatusCode.Moved)
        {
            return response.Headers.Location.AbsoluteUri;
        }
        return url;
    } 
