    static void Main(string[] args)
    {
        var client = new HttpClient();
        var uri = new Uri("http://localhost:55501/WebService1.asmx/HelloWorld")
        // Get xml
        var response = client.PostAsync(uri, new StringContent("")).Result;
        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        Console.WriteLine();
        // Get Json
        var response1 = client.PostAsync(uri,
            new StringContent("", Encoding.UTF8, "application/json")).Result;
        Console.WriteLine(response1.Content.ReadAsStringAsync().Result);
    }
