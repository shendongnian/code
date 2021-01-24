    public class Startup {    
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IServiceProvider ConfigureServices(IServiceCollection services) {
    
            // Adding service for daily job. Use your preferred life time scope as necessary  
            services.AddScoped<IScheduledTaskService, ScheduledTaskService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //add other dependencies...
            
            services.AddHangfire(x => x.UseSqlServerStorage("<connection string>"));
    
            //configure Autofac
            this.ApplicationContainer = getWebAppContainer(services);
            //get service provider    
            return new AutofacServiceProvider(this.ApplicationContainer);
        }
        IContainer getWebAppContainer(IServiceCollection service) {
            var builder = new ContainerBuilder();        
            builder.RegisterModule(new BusinessBindingsModule());
            builder.RegisterModule(new DataAccessBindingsModule());
            builder.Populate(services);
            return builder.Build();
        }        
    
        public void Configuration(IApplicationBuilder app) {
            // app.AddLogger...
    
            // Creates and starts a new background job server instance,
            // and registers an application stop handler for graceful
            // shutdown.
            app.UseHangfireServer();
    
            // Enables the Dashboard UI middleware to listen on `/hangfire`
            // path string.
            app.UseHangfireDashboard();
    
            //Add the recurring job
            RecurringJob.AddOrUpdate<IScheduledTaskService>(task => task.DailyJob(), Cron.Daily);
    
            //app.UseMvc...
            //...other code
        }
    
        //...other code
    }
