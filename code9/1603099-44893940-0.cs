    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartup(typeof(DotNetNuclear.Modules.LogAnalyzer.Components.Startup))]
    
    namespace DotNetNuclear.Modules.LogAnalyzer.Components
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ...
                app.MapSignalR();
            } 
        }
    }
