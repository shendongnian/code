        HttpClient client = ...
        ...
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri("some url"),
            Method = HttpMethod.Get,
        };
        request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("some json"));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await client.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
