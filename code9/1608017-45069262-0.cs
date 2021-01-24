    using (var client = new HttpClient())
        {
            var request = BuildRelayHttpRequest(Request);
            await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        }
        try
        {
            response.EnsureSuccessStatusCode();
            // Handle success
        }
        catch (HttpRequestException)
        {
            // Handle failure
        }   
    }
