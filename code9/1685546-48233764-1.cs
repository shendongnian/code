    public async Task<HttpResponseMessage> GetUsTraceApiHealth()
    {
    	using (HttpClient httpClient = new HttpClient())
    	{
    		try
    		{
    			string uri = $"https://trace.{ConfigHelper.SterlingDomain}health?deep";
    
    			HttpResponseMessage apiResponse = await httpClient.GetAsync(uri).ConfigureAwait(false);
    			return apiResponse;
    		}
    		catch (Exception e)
    		{
    			throw new Exception(e.Message);
    		}
    	}
    }
