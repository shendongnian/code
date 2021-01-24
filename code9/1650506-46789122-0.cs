    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHost(args)
               .Build()
               .Run();
        }
    
        public static IWebHostBuilder CreateWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices((services) =>
                {
                    //Setup autofac.
                    services.AddAutofac();
                    //Register module dependency that Startup requires.
                    services.AddTransient<Module, MyAutofacModule>();
                    ////It would a bit cleaner to use autofac to setup Startup dependency,
                    ////but dependency did not get resolved for Startup.
                    //services.AddAutofac((builder) =>
                    //{
                    //   builder.RegisterModule(new AutofacModule());
                    //});
                })
                .UseStartup<Startup>();
    }
    public class MyAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register all application dependencies in this module.
            builder.Register((c) => new ExternalService()).As<IExternalService>();
        }
    }
    public class Startup
    {
        private Module applicationDIModule;
        public Startup(Module applicationDIModule)
        {
            this.applicationDIModule = applicationDIModule;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //We can add build-in services such as mvc and authorization,
            //but I would not use Add(Transient/Scoped/Singleton) here.
            //You should register domain specific dependecies in MyAutofacModule,
            //since it will be added after this method call.
            services.AddMvc();
        }
        //This method is called after ConfigureServices (refer to Autofac link).
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //We will register injected module.
            builder.RegisterModule(applicationDIModule);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
        }
    }
