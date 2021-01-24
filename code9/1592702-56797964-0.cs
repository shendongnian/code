    Uri baseAddress = new Uri("https://" + "www.url.com");
                        CookieContainer cookieContainer = new CookieContainer();
                        using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                        using (HttpClient client = new HttpClient(handler) { BaseAddress = baseAddress })
                        using (MultipartFormDataContent content = new MultipartFormDataContent())
                        {
                            KeyValuePair<string, string>[] values = new[]
                                                      {
                new KeyValuePair<string, string>("attachment", ""),
                
            };
                            
    
                         
    
    
                            foreach (KeyValuePair<string, string> keyValuePair in values)
                            {
                                content.Add(new StringContent(keyValuePair.Value), string.Format("\"{0}\"", keyValuePair.Key));
                            }
    
                            //for cookies
                            cookieContainer.Add(baseAddress, new Cookie("name", "value"));
    
    
    
                            client.DefaultRequestHeaders.Add("cache-control", "no-cache");
                            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 8.0.0; SM-G960F Build/R16NW) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.84 Mobile Safari/537.36");
                            //client.DefaultRequestHeaders.Add("Content-Type", "multipart/form-data");
                            client.DefaultRequestHeaders.Add("DNT", "1");
                            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                            client.DefaultRequestHeaders.Add("Origin", "https://www.url.com");
    
                            string finalUrl = "/url";
                           
    
                            using (HttpResponseMessage result = await client.PostAsync(finalUrl, content))
                            {
                                string input = await result.Content.ReadAsStringAsync();
    
                                if (result.IsSuccessStatusCode)
                                {
                                    return true;
                                }
                            }
                        }
 
