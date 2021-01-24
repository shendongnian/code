    private static HttpClient client1;
    private static HttpClient client2;
    private static HttpClient client3;
    // HttpClient should be initialized once for whole application life-cycle
    // Execute code below somewhere in your initialization
    client1 = new HttpClient();
    client1.BaseAddress = new Uri("https://website1.com");
    client2 = new HttpClient();
    client2.BaseAddress = new Uri("https://website2.com");
    client3 = new HttpClient();
    client3.BaseAddress = new Uri("https://website3.com");
   
    public async Task<IEnumerable<string>> GetDataAsync(string address, string postalCode)
    {
        var path = $"{address} {postalCode}"; // build proper path for request
        var textFrom1 = await client1.GetAsync(path); // Base address already added;
        if (textFrom1.Split(':', ',')[1] != "1")
        {
            return Enumerable.Repeat("empty", 3);
        }
        var textFrom2 = await client2.GetAsync(textFrom1.Split('"', '"')[11]);
        var textFrom3 = await client3.GetAsync(textFromUrl.Split('"', '"')[3]);
        var allData = JsonConvert.DeserializeObject<List<RootObject>>(textFrom3);
        var item = allData.First();
        return new[]
        {
            item.hoofdadres.geocodeerServiceZoekString,
            item.gebruiksdoel,
            item.begindatum.ToString()
        };
    }
