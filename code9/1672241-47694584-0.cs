    class Example
    {
        static void Main()
        {
            var client = HttpClientFactory.Create(new Handler());
            client.BaseAddress = new Uri("http://www.example.local");
            var r = client.GetAsync("").Result;
            Console.WriteLine(r.StatusCode);
            Console.WriteLine(r.Headers.ETag);
        }
    }
    class Handler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var headerName = "ETag";
            var r = await base.SendAsync(request, cancellationToken);
            var header = r.Headers.FirstOrDefault(x => x.Key == headerName);
            var updatedValue = header.Value.Select(x => x.StartsWith("\"") ? x : "\"" + x + "\"").ToList();
            r.Headers.Remove(headerName);
            r.Headers.Add(headerName, updatedValue);
            return r;
        }
    }
