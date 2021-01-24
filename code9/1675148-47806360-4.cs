    public static class HttpResponseMessageExtensions
    {
    	public static bool IsRedirected(this HttpResponseMessage response)
    	{
    		var code = response.StatusCode;
    		return code == HttpStatusCode.MovedPermanently || code == HttpStatusCode.Found;
    	}
    }
    
    bool redirected = response.WasRedirected();
