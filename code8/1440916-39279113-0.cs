    public class MyClass()
    {
    private HttpClient client = null;
    public MyClass(){
    	client = new HttpClient();
    	client.SetBearerToken("access token here");
    	client.BaseAddress = new Uri("MyBaseUrl.com");
    	client.DefaultRequestHeaders.Accept.Clear();
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	
    }
    public async Task<string> PostMessageToAPI(string aMsg)
    {
        HttpResponseMessage response = null;
        string strResponse = "";    
        try
        {
    		using (response =  await client.PostAsJsonAsync("my/url/goes/here", anEvent.ToLower()))
    		{
    			if (response != null)
    			{
    				if (response.StatusCode != HttpStatusCode.OK)
				    {
					    throw new HttpRequestException(response.ReasonPhrase);
				    }
				    else
				    {
					    return await response.Content.ReadAsStringAsync();
				    }
			    }
		    }
        
        }
        catch (HttpRequestException ex)
        {       
            //  exception message states: "An error occurred while sending the request"
        }   
        return strResponse;           
    }
    }
