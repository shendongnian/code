    protected void Application_Start()
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
    
                JsonSerializerSettings serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
                serializerSettings.TypeNameHandling = TypeNameHandling.All;
                serializerSettings.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                serializerSettings.FloatParseHandling = FloatParseHandling.Decimal;
    
                FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);
    
            }
