    public static class AuthenticationExtensions
    {
    	public static Authentication Authenticate(this HttpRequest @this)
    	{
    		var handler = new HttpClientHandler();
    		var client = new HttpClient(handler) // Will want to make this a singleton.  Do not use in production environment.
    		{
    			BaseAddress = new Uri(Environment.GetEnvironmentVariable("AuthenticationBaseAddress") ?? new Uri(@this.GetDisplayUrl()).GetLeftPart(UriPartial.Authority))
    		};
    		handler.CookieContainer.Add(client.BaseAddress, new Cookie("AppServiceAuthSession", @this.Cookies["AppServiceAuthSession"] ?? Environment.GetEnvironmentVariable("AuthenticationToken")));
    
    		var service = RestService.For<IAuthentication>(client);
    
    		var result = service.GetCurrentAuthentication().Result.SingleOrDefault();
    		return result;
    	}
    }
