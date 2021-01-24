    public static async void ListenForSearchQueries(int resourceId)
    {
        var url = $"xxx/yyy/{resourceId}/waitForSearchRequest?token=abc";
    
        var httpHandler = new HttpClientHandler { PreAuthenticate = true };
    
        using (var digestAuthMessageHandler = new DigestAuthMessageHandler(httpHandler, "user", "password"))
        using (var client = new HttpClient(digestAuthMessageHandler))
        {
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
    
            var request = new HttpRequestMessage(HttpMethod.Get, url);
    
            var tokenSource = new CancellationTokenSource();
                tokenSource.CancelAfter(TimeSpan.FromMilliseconds(Timeout.Infinite));
    
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, tokenSource.Token))
            {
                Console.WriteLine("\nResponse code: " + response.StatusCode);
    
                using (var body = await response.Content.ReadAsStreamAsync())
                {
                    body.ReadTimeout = Timeout.Infinite;
                    
                    using (var reader = new StreamReader(body))
                        while (!reader.EndOfStream)
                            Console.WriteLine(reader.ReadLine());
                }
             }
        }
    }
