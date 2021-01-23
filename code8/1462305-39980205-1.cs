    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
    
            config.Filters.Add(new CustomAuthenticationAttribute ());
        }
    }
