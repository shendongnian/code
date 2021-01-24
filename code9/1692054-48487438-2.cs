    using (var client = new HttpClient())
    {
    	//set up client
    	client.BaseAddress = new Uri(Baseurl);
    	client.DefaultRequestHeaders.Clear();
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    	var requestUri = new Uri($"api/home/processfields?field1={HttpUtility.UrlEncode(field1)}&field2={HttpUtility.UrlEncode(field2)}&field4={HttpUtility.UrlEncode(field4)}", UriKind.Relative);
        var content = new StringContent($"\"{field3}\"", Encoding.UTF8, "application/json");
    	var response = await client.PostAsync(requestUri, content);
        var result = await response.Content.ReadAsStringAsync();
    }
