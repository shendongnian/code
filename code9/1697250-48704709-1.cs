       var handler = new HttpClientHandler()
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    };
       using (var client = new HttpClient(handler))
       {
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            response = client.GetStringAsync("http://scooterlabs.com/echo").Result;
       }
