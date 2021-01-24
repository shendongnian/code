    static void Main(string[] args)
    {
        string url = "http://careers.adidas-group.com";
        var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };
        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
        client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0");
        client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
        using (var message = new HttpRequestMessage(HttpMethod.Get, url))
        {
            using (var httpResponse = Task.Run(() => client.SendAsync(message)).Result)
            {
                Console.WriteLine("{0}: {1}", httpResponse.StatusCode, httpResponse.ReasonPhrase);
            }
        }
        Console.ReadLine();
    }
