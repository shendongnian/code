    public async Task<API_Json.RootObject> walMart_Lookup(string url)
        {
            lookupIsWorking = true;
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            using (HttpClient http = new HttpClient(handler))
            {
                http.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
                http.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                url = String.Format(url);
                using (var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    Console.WriteLine(response);
                    var serializer = new JsonSerializer();
                    using (StreamReader sr = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    {
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {
                            var root = serializer.Deserialize<API_Json.RootObject>(jsonTextReader);
                           lookupIsWorking = false;
                            return root;
                        }
                    }
                }
            }
        }
