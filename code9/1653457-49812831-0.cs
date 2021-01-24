    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            /// ...
    
            var converters = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters;
    
            converters.Add(new FruitConverter());
            converters.Add(new PearConverter());
        }
    }
