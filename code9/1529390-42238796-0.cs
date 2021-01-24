    private HttpResponseMessage SetToJson(string jsonString) { 
        string str = "ABC";
    
        var Request = new HttpRequestMessage();
        Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        Request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
    
        var obj = JsonConvert.DeserializeObject(jsonString);
    
        return Request.CreateResponse(HttpStatusCode.OK, new { obj, str }, JsonMediaTypeFormatter.DefaultMediaType);
    }
