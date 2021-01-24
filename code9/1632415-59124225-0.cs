    using (var client = new HttpClient())
    {
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
    	client.DefaultRequestHeaders.Add("Accept", "*/*");
    
    	var Parameters = new List<KeyValuePair<string, string>>
    	{
    		new KeyValuePair<string, string>("Id", "1"),
    	};
    
    	var Request = new HttpRequestMessage(HttpMethod.Post, "Post_Url")
    	{
    		Content = new FormUrlEncodedContent(Parameters)
    	};
    
    	var Result = client.SendAsync(Request).Result.Content.ReadAsStringAsync();
    }
