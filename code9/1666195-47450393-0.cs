    using Microsoft.Owin;
    using Owin;
    [assembly: OwinStartupAttribute(typeof(CL.Startup))]
    namespace CL
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR();
            
              
               
            }
        }
    } 
