    using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://path/to/wherever"))
    {
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "TheToken");
        using (var httpResponseMessage = httpClient.SendAsync(httpRequestMessage))
        {
            // ...
        }
    }
