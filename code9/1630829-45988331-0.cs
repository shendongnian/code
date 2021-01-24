    string token = "Oauth token received using some mechanism";    
    string requestPath = string.Format("v1/tag");
    
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://api.clarifai.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    
    HttpResponseMessage response = await client.PostAsync(requestPath, content);
    if (response.IsSuccessStatusCode)
    {
        var resString = await response.Content.ReadAsStringAsync();
        // JSON Response
        JObject resJsonObject = JObject.Parse(resString);
 
    }
