     public async Task<string> webClient(string method, string uri)
            {
                    try
                    {
        
                        var client = new HttpClient();
                        client.Timeout =new TimeSpan(0,0,0,10);
                        client.BaseAddress = new Uri(uri);
                        client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync(method).Result;
        
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
        
                    }
                    catch (Exception ex)
                    {
                        return "Error";
                    }
    }
