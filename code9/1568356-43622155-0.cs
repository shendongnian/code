    private static Action<NancyContext> RedirectUnauthorizedRequests()
    {
    	return context =>
    	{
    		if (context.Response.StatusCode == HttpStatusCode.Unauthorized)
    		{
    			context.Response = context.GetRedirect("/login");
    		}
    	};
    }
