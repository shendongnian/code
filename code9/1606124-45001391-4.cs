    string formActionUrl = @"https://someposturl.com";
    
    var formInputData = new Dictionary<string, string>
    {
    	{ "input1", "hello" },
    	{ "input2", "world" }
    };		
    	
    using (var client = new System.Net.Http.HttpClient())
    {
    	var content = new FormUrlEncodedContent(formInputData);
    	
    	var response = client.PostAsync(formActionUrl, content).Result;
    	
    	var responseHtmlString = response.Content.ReadAsStringAsync().Result;
    }
