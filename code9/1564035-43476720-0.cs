    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver());
            // Web API routes
            config.MapHttpAttributeRoutes();            
        }
    }
