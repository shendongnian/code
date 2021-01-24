    var baseAddress = new Uri("http://servername/webapi1/GetUserInfo");
    	using (var httpClient = new HttpClient {BaseAddress = baseAddress})
    	{
    		using (var response = httpClient.GetAsync(userName).Result)
    		{
    			if(response.StatusCode == System.Net.HttpStatusCode.OK)
    				trackingResponse = response.Content.ReadAsStringAsync().Result;
    		}
    	}
