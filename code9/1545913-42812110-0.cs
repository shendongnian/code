    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            var container = UnityConfig.GetConfiguredContainer();
             
            //...any other settings to be applied to container.
            config.DependencyResolver = new UnityDependencyResolver(container);
            //...other code removed for brevity
        }
    }
