    Dictionary<string, string> formContent= new Dictionary<string, string>();
    mapObject.Add("mobile_numbers","5555555555");
    mapObject.Add("message","Whoo hahahahah")
        
    var jsonString = JsonConvert.SerializeObject(formContent);
    
    WebRequestHandler handler = new WebRequestHandler();
    X509Certificate2 certificate = GetMyX509Certificate();
    handler.ClientCertificates.Add(certificate);
    HttpClient client = new HttpClient(handler);
    client.BaseAddress = new Uri("https://api.iwin.co.za");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("Authorization", "Bearer 134134134");
                
    HttpResponseMessage response = client.PostAsync("/iwin/api/v1/messages", getHttpContent(jsonString)).Result;
