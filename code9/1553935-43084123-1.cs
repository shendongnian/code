    protected void Application_Start()
    {
         GlobalConfiguration.Configure(ServerConfig.Configure);
    }
    void Configure(HttpConfiguration config)
    {
          var formatters = config.Formatters;
          var jsonFormatter = formatters.JsonFormatter;
          // "text/html" is the default browser request content type
          jsonFormatter.SupportedMediaTypes.Add(new 
          MediaTypeHeaderValue("text/html"));
          WebApiConfig.Register(config);
          RegisterDependencies();
     }
