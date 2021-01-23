    using (var client = new HttpClient())  //  <------ this gets disposed
    {    	
    	for (int i = 0; i < 100; i++)
    	{
    		using (var response = client.GetAsync("http://google.com").Result)  //  <--- and this
    		{
    			string responseString = response.Content.ReadAsStringAsync().Result;
    		}
    	}
    }
