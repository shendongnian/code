    public async Task<SearchDataResponse> SearchAsync(string query, string accessToken)
    {
        using (HttpRequestMessage request = new HttpRequest(HttpMethod.Get, uri)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            var response = await httpClient.SendAsync(request);
            ...
        }
    }
