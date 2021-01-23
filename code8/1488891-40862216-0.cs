    var take	    = 500;
    var skip	    = 0;
    var postCount	= 0;
    
    while(result.messages.Count == postCount)
    {
    	using(var handler = new HttpClientHandler { CookieContainer = cookieContainer })
    	{
    		using(var client = new HttpClient(handler) { BaseAddress = url, Timeout = new TimeSpan(0, 2, 0) })
    		{
    			cookieContainer.Add(domain, new Cookie(cookie.Name, cookie.Value));
    						
    			query["Skip"]        = skip;
    			query["Take"]        = take;
    			builder.Query        = query.ToString();
    			url                  = builder.Uri;
    			client.BaseAddress   = url;
    
    			var response	= await client.GetAsync(url);
    
    			if(response.IsSuccessStatusCode)
    			{
    				// succeeded
    				skip	    += take;
    				postCount	+= take;
    			}
    			else if(response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
    			{
    				// timeout, we reduce the number of messages to take. 
    				take		-= 100;
    			}
    		}
    	}
    }
