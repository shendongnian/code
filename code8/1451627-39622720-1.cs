    public static Task<DiscoveryElement[]> DiscoverBridgesAsync() 
    {
        using (var client = new HttpClient())
        {
            var result = await client.GetAsync(DISCOVERY_URI);
            return await result.Content.ReadAsAsync<DiscoveryElement[]>();     
        }
    }
