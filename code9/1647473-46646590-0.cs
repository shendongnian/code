    using System.Net.Http;
    //...
    var loToken = new
    {
        token = "token",
        voice_samples = new List<dynamic>()
        {
            new {wave = "string1"},
            new {wave = "string2"},
            new {wave = "string3"}
        }
    };
    
    var loClient = new HttpClient() { BaseAddress = new Uri(endpoint) };
    var loResp = await loClient.PostAsJsonAsync("", loToken);
    Console.WriteLine(loResp.StatusCode.ToString());
