    public async Task<SearchDataResponse> SearchAsync(string query, string accessToken)
    {
        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            var response = await httpClient.SendAsync(request);
            ...
        }
    }
