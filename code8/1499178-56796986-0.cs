    public async Task<Stream> GetWebData(string url, CancellationToken? c = null)
    {
        using (var httpClient = new HttpClient())
        {
            var t = httpClient.GetAsync(new Uri(url), c ?? CancellationToken.None);
            var r = await t;
            return await r.Content.ReadAsStreamAsync();
        }
    }
