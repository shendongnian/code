    //get username and password from publish profile on Azure portal
    var username = "xxxxx";
    var password = "xxxxxxxxxxxxxxxxxxxx";
    var AppName = "{your_app_name}";
    
    var base64Auth = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));
    var file = File.ReadAllBytes(@"C:\Users\xxx\xxx\WebApplication1.zip");
    MemoryStream stream = new MemoryStream(file);
    
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64Auth);
        var baseUrl = new Uri($"https://{AppName}.scm.azurewebsites.net/");
        var requestURl = baseUrl + "api/zip/site/wwwroot";
        var httpContent = new StreamContent(stream);
        var response = client.PutAsync(requestURl, httpContent).Result;
    }
