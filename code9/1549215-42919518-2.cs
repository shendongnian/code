    public static async Task<RootObject> GetAsync()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "something");
        var json = await client.GetStringAsync("http://api.promasters.net.br/cotacao/v1/valores");
        return JsonConvert.DeserializeObject<RootObject>(json);
    }
