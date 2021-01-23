    public static async Task<string> GetRequest(string url, 
                                                string user, 
                                                string pass)
    {
        var credentials = new System.Net.NetworkCredential(user, pass);
        using (var handler = new HttpClientHandler { Credentials = credentials })
        {
            using (var client = new HttpClient(handler))
            {
                using (var response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }        
    }
