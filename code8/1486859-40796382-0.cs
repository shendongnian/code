    static async Task<string> GetAuthenticationTokenAsync() {
        string token = string.Empty;
        
        var clientId = ConfigurationManager.AppSettings["AuthNClientId"];
        var uri = ConfigurationManager.AppSettings["AuthNUri"];
        var userName = ConfigurationManager.AppSettings["AuthNUserName"];
        var password = ConfigurationManager.AppSettings["AuthNPassword"];
        var client = new HttpClient();
        client.BaseAddress = new Uri(uri);
        client.DefaultRequestHeaders.Accept.Clear();
        
        var nameValueCollection = new Distionary<string, string>() {
            { "client_id", clientId },
            { "grant_type", "password" },
            { "username", userName },
            { "password", password },
        };
        var content = new FormUrlEncodedContent(nameValueCollection);
        var response = await client.PostAsync("", content);
        if (response.IsSuccessStatusCode) {
            Console.WriteLine("success");
            var json = await response.Content.ReadAsStringAsync();
            dynamic authResult = JsonConvert.DeserializeObject(json);
            token = authResult.access_token;
        }
        else { Console.WriteLine($"failure: {response.StatusCode}"); }
        return token;
    }
