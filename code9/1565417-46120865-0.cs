    private static async Task StreamAsync(string url, string username, string password)
        {
            var handler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential {UserName = username, Password = password},
                PreAuthenticate = true
            };
            // Client can also be singleton
            using (var client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Connection.Add("keep-alive");
                
                using (var response = await client.SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead))
                {
                    using (var body = await response.Content.ReadAsStreamAsync())
                    {
                        using (var reader = new StreamReader(body))
                        {
                            while (!reader.EndOfStream)
                            {
                                var buffer = new char[1024];
                                await reader.ReadBlockAsync(buffer, 0, buffer.Length);
                                Console.WriteLine(new string(buffer));
                            }
                        }
                    }
                }
            }
        }
