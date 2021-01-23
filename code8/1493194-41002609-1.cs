    public static class WebApiConfig
    {
    	public static void Register(HttpConfiguration config)
    	{
    		// Web API routes
    		config.MapHttpAttributeRoutes();
    
    		config.Routes.MapHttpRoute(
    			name: "DefaultApi",
    			routeTemplate: "api/{controller}/{id}",
    			defaults: new { id = RouteParameter.Optional }
    		);
    
    		//Clear current formatters
    		config.Formatters.Clear();
    		
    		//Add only a json formatter
    		config.Formatters.Add(new JsonMediaTypeFormatter());
    
    	}
    }
