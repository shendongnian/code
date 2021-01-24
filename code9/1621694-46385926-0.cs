    public Task<string> GetHtmlAsync(string url)
    {
    	try
    	{
    		var t = Task.Run(async () => {
    			using (var client = new HttpClient())
    			{
    				var response = await client.GetAsync(url);
    				return await response.Content.ReadAsStringAsync();
    			}
    		});
    		return t;
    	}
    	catch (HttpRequestException e)
    	{
    		return Task.FromException<string>(e);
    	}
    }
