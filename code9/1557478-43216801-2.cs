    static void Main(string[] args) => Task.Run(() => MainAsync(args)).Wait();
    
    static async Task MainAsync(string[] args)
    {
        var result = await GetResponseFromURI(new Uri("http://www.google.com"));
        Console.WriteLine(result);
        Console.ReadLine();
    }
    
    static async Task<string> GetResponseFromURI(Uri u)
    {
        var response = "";
        using (var client = new HttpClient())
        {
            HttpResponseMessage result = await client.GetAsync(u);
            if (result.IsSuccessStatusCode)
            {
                response = await result.Content.ReadAsStringAsync();
            }
        }
        return response;
    }
