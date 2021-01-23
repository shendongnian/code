    public async Task<IList<HttpStatusCode>> GetStatusCodes(IList<string> urls)
    {
        var client = new HttpClient();
        var result = new List<HttpStatusCode>();
        foreach (var url in urls)
        {
            var response = await client.GetAsync(url);
            result.Add(response.StatusCode);
        }
        return result;
    }
