       public static async Task PutImage(string url, byte[] image)
       {
            var httpContent = new ByteArrayContent(image);
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(DataServiceAddress + "Data/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
                using (var request = new HttpRequestMessage(HttpMethod.Put, url) { Content = httpContent })
                {
                    
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                    using (var message = await client.SendAsync(request))
                    {
                        message.EnsureSuccessStatusCode();
                    }
                }
            }
        }
