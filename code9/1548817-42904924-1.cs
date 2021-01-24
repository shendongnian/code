    using (HttpClient client = new HttpClient())
    {
    	using (HttpRequestMessage request = new HttpRequestMessage())
    	{
    		request.Method = HttpMethod.Get;
    		request.RequestUri = new Uri("http://www.google.com", UriKind.Absolute);
    
    		using (HttpResponseMessage response = await client.SendAsync(request))
    		{
    			if (response.IsSuccessStatusCode)
    			{
    				if (response.Content != null)
    				{
    					var result = await response.Content.ReadAsStringAsync();
    					// write result to file
    				}
    			}
    		}
    	}
    }
