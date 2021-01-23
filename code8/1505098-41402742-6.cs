    protected void Application_Start()
    {
         ...
         //next line registers web api routes
         GlobalConfiguration.Configure(WebApiConfig.Register);
         ...
         //next line registers mvc routes
         RouteConfig.RegisterRoutes(RouteTable.Routes); 
         ...
    }
