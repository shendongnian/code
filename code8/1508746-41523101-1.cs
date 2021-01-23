     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net.Http.Formatting;
        using System.Text;
        using System.Threading.Tasks;
        using System.Web.Http;
        using Fwd.Business.EF.IService;
        using Fwd.Business.EF.Service;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Serialization;
        using Ninject;
        using Ninject.Web.Common.OwinHost;
        using Ninject.Web.WebApi.OwinHost;
        using Owin;
      
        
        namespace SelfHostSIAE
        {
            public class Startup
            {
                // This code configures Web API. The Startup class is specified as a type
                // parameter in the WebApp.Start method.
                public void Configuration(IAppBuilder appBuilder)
                {
                    // Configure Web API for self-host. 
                    HttpConfiguration config = new HttpConfiguration();
        
        
                    config.MapHttpAttributeRoutes();
                    config.Routes.MapHttpRoute(
                      name: "DefaultApi",
                      routeTemplate: "api/{controller}/{id}",
                      defaults: new { id = RouteParameter.Optional }
                  );
        
                    var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
                    jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    // jsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        
                    appBuilder.UseErrorPage();
                    appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                    appBuilder.UseNinjectMiddleware(CreateKernel);
                    appBuilder.UseNinjectWebApi(config);
                    //appBuilder.UseWebApi(config);
                }
        
                public static IKernel CreateKernel()
                {
                    var kernel = new StandardKernel();
        
                    kernel.Bind<IWebSettingBll>().To<WebSettingBll>().InSingletonScope(); //<-- IF YOU WANT  A SINGLETON
                    kernel.Bind<IPageBll>().To<PageBll>();
                    kernel.Bind<ILogger>().To<Logger>();
                    kernel.Bind<IHomeBll>().To<HomeBll>();
                    kernel.Bind<IHitCountBll>().To<HitCountBll>();
                    return kernel;
                }
            }
        }
