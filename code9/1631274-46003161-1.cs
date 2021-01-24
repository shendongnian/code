                using (var client = new HttpClient(new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    CookieContainer = new CookieContainer()
                }))
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"));
                    client.DefaultRequestHeaders.Referrer = new Uri("https://twitter.com/settings/account");
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
                    // Get
                    var result = await client.GetAsync(new Uri(""));
                    if (result.IsSuccessStatusCode)
                    {
                        var content = await result.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"{result.StatusCode}: {await result.Content.ReadAsStringAsync()}");
                    }
                    // Post
                    var post = await client.PostAsync("Uri", new StringContent("could be serialized json or you can explore other content options"));
                    if (post.IsSuccessStatusCode)
                    {
                        var contentStream = await post.Content.ReadAsStreamAsync();
                        var contentString = await post.Content.ReadAsStringAsync();
                    }
                }
