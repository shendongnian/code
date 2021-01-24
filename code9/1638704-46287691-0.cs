    HttpClientHandler handler = new HttpClientHandler();
    handler.Credentials = new NetworkCredential("test", "testing");
    HttpClient client = new HttpClient(handler);
    client.BaseAddress = new Uri("http://test.abctesting.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
    string user = "user", password = "password";
    
    string userAndPasswordToken =
        Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password));
    
    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", 
        $"Basic {userAndPasswordToken}");
    
    HttpResponseMessage response = client.GetAsync("admin/apiv2/").Result;
    var tenders = response.Content.ReadAsAsync<tenders>().Result;
