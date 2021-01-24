    public class WebApiConfig
    {
        // ...
    
        public void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("<origins>", "<headers>", "<methods>")
            {
                SupportsCredentials = true // If you need to pass them
            });
    
            // ...
        }
    }
