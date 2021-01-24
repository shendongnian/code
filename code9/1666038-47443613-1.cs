    static readonly Lazy<HttpClient> _clientHolder = new Lazy<HttpClient>(() => CreateHttpClient(TimeSpan.FromSeconds(60)));
    static HttpClient Client => _clientHolder.Value;
    protected static async Task<HttpResponseMessage> PostObjectToAPI<T>(string apiUrl, T data)
    {
        var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(data)).ConfigureAwait(false);
        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        try
        {
            return await Client.PostAsync(apiUrl, httpContent).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return null;
        }
    }
    static HttpClient CreateHttpClient(TimeSpan timeout)
    {
        var client = new HttpClient();
        client.Timeout = timeout;
        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        return client;
    }
