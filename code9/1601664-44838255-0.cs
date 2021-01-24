     public class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                //Routes
                config.Routes.MapHttpRoute(/// your routes);
    
                //Formatters
                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            }
        }
