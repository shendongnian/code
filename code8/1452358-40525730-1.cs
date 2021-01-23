    var config = new HttpConfiguration();
    
    // Configure your origins as required.
    
    var cors = new EnableCorsAttribute("*", "*", "*");
    
    config.EnableCors(cors);
    
    FormatterConfig.ConfigureFormatters(config.Formatters);
    
    RouteConfig.RegisterRoutes(config.Routes);
    
    appBuilder.UseWebApi(config);
               
    GlobalHost.DependencyResolver.UseServiceBus("yourconnection string comes here", "signalrbackplaneserver");
    appBuilder.UseAesDataProtectorProvider("some password");
    appBuilder.Map("/echo", map =>
    {
                    map.UseCors(CorsOptions.AllowAll).RunSignalR<MyEndPoint>();
    });
