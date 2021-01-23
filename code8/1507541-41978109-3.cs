    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
    
            config.MessageHandlers.Add(new HttpErrorHandler());
            
            // Other code not shown...
        }
    }
