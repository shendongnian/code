    using Microsoft.Owin;
    using Owin;
    using System.Web.Http;
    [assembly: OwinStartup(typeof(WebApiAndStaticFiles.OwinStartup))]
    
    namespace WebApiAndStaticFiles
    {
        public class OwinStartup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
    
                HttpConfiguration webApiConfiguration = new HttpConfiguration();
                GlobalConfiguration.Configure(webApiConfiguration); // Instead of GlobalConfiguration.Configure(WebApiConfig.Register);
                app.UseWebApi(webApiConfiguration);
    
            }
        }
    }
