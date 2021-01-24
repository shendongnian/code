    protected void Application_Start()
            {
                GlobalConfiguration.Configure(ServerConfig.Configure);
            }
 
    void Configure(HttpConfiguration config)
            {
                var formatters = config.Formatters;
                var jsonFormatter = formatters.JsonFormatter;
                jsonFormatter.SupportedMediaTypes.Add(new 
                MediaTypeHeaderValue("text/html")); //"text/html" is the default 
                browser request content type
                WebApiConfig.Register(config);
                RegisterDependencies();
            }
