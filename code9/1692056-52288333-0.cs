    bodyClass obj = new bodyClass();
    obj.empName= "your param value";
    string DATA = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    
    var client = new HttpClient();
    HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
    HttpResponseMessage messge = client.PostAsync("your api url", content).Result;
    
    if (messge.IsSuccessStatusCode)
    {
          string result = messge.Content.ReadAsStringAsync().Result;
    }
