    private async Task<Response> GetResult(dynamic parameters, CancellationToken ct)
    {
        var client = new HttpClient();
        //this is only a Simple Change to demonstrate the problem
        var req = Request.Url.ToString();
        var queryStart= req.IndexOf("url=");
        string url = req.Substring(queryStart+4);
        if (url == null) return null;
        client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
        client.DefaultRequestHeaders.Add("User-Agent",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
        client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
        client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, sdch, br");
        client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");
        var response = await client.GetAsync(url, ct);
        ct.ThrowIfCancellationRequested();
        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                var stream = await response.Content.ReadAsStreamAsync();
                return Response.FromStream(stream, response.Content.Headers.ContentType != null
                    ? response.Content.Headers.ContentType.ToString()
                    : "application/octet-stream");
            default:
                return Response.AsText("\nError " + response.StatusCode);
        }
    }
