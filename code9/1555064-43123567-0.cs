    [assembly: OwinStartup(typeof(WebApiOwinAutoFac.Startup))]
    namespace WebApiOwinAutoFac
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var builder = new ContainerBuilder();
    
                // STANDARD WEB API SETUP:
    
                // Get your HttpConfiguration. In OWIN, you'll create one
                // rather than using GlobalConfiguration.
                var config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
                // Register your Web API controllers.
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    
                // builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
                builder.RegisterType<TestRepository>().As<ITestRepository>();
    
                // Run other optional steps, like registering filters,
                // per-controller-type services, etc., then set the dependency resolver
                // to be Autofac.
                var container = builder.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    
                // OWIN WEB API SETUP:
    
                // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
                // and finally the standard Web API middleware.
                app.UseAutofacMiddleware(container);
                app.UseAutofacWebApi(config);
                app.UseWebApi(config);
    
                ConfigureAuth(app);
            }
        }
    }
