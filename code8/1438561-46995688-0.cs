    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartupAttribute(typeof(ProjectNameSpace.Startup))]
    
    namespace ProjectNameSpace
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
            }
        }
    }
