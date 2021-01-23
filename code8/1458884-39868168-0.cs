    public static async Task<string> GetRequest(string url, 
                                                string user, 
                                                string pass)
    {
        using (HttpClientHandler handler = new HttpClientHandler { Credentials = new System.Net.NetworkCredential(user, pass) })
        {
            using (HttpClient client = new HttpClient(handler))
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }        
    }
