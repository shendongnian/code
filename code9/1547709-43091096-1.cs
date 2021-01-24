    static async void SendRequest()
    {
        HttpClient client = new HttpClient();
        string token = "";
        for (int i = 0; i < 2050; i++)
        {
            token = token + "0";
        }
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage message = await client.GetAsync("http://xxx.azurewebsites.net/");
        string content = await message.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
