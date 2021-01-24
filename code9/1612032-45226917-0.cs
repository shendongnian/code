    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartup(typeof(YOUR_PROJECT_NAMESPACE.Startup))]
    namespace YOUR_PROJECT_NAMESPACE
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
            }
        }
    }
