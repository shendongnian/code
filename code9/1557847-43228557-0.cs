    HttpClient client = new HttpClient();
    var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));
    var response = await client.GetAsync (uri);
    if (response.IsSuccessStatusCode) 
    {
       var content = await response.Content.ReadAsStringAsync ();
       var objectResult = JsonConvert.DeserializeObject <YourObject> (content);
    }
