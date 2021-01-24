    using System.Web.OData.Extensions;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.EnableDependencyInjection();
        }
    }
