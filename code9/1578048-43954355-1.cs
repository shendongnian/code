    using System.Net.Http;
    using System.Net.Http.Headers;
    
    private const string Url = "https://api.twitch.tv/kraken/streams/channelname";
    public static async Task<string> GetResponseFromTwitch()
    {
        using(var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.twitchtv.v5+json"));
            client.DefaultRequestHeaders.Add("Client-ID", "MyId");
            
            using(var response = await client.GetAsync(Url))
            {
                response.EnsureSuccessStatusCode();
            
                return await response.Content.ReadAsStringAsync(); // here we return the json response, you may parse it
            }
        }    
    }
