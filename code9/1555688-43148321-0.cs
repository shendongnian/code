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
    static void Main(string[] args)
    {
        var t = Task.Run(() => GetResponseFromURI(new Uri("http://www.google.com")));
        t.Wait();
                
        Console.WriteLine(t.Result);
        Console.ReadLine();
    }
