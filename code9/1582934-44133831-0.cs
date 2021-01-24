    List<Section> sections = new List<Section>();
    HttpClient client = new HttpClient();
    string geturl = "http://192.168.0.60/mdaswebservices/api/inventory/section/";
    HttpResponseMessage response = client.GetAsync(geturl).Result;
    if (response.IsSuccessStatusCode)
    {
        sections  = response.Content.ReadAsAsync<List<Section>>().Result;
    }
    else
    {
        sections = new List<Section>();
    }
