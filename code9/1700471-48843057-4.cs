    HttpClient client = new HttpClient();
    client.BaseAddress = new System.Uri("http://localhost:51022/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");    
    var response = await client.PostAsync("/api/NativeClient/", httpContent);
