    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartupAttribute(typeof({project_name}.Startup))]
    
    namespace AuctionPortal
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
            }
        }
    }
