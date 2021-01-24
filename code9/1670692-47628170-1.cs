    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new RequestLoggingHandler());
            //... the rest of the setup...
        }
    }
