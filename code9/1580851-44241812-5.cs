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
            // Configures Hangfire with the following methods exposed on 
            // the IGlobalConfiguration interface, and registers all the
            // required classes, including logging and DI, using new DI 
            // abstraction.
            services.AddHangfire(x => x.UseSqlServerStorage("<connection string>"));
    
            // Adding service for daily job. Use your preferred life time scope if necessary  
            services.AddScoped<IScheduledTaskManager, ScheduledTaskManageImplementation>();
            //add other dependencies...
    
            this.ApplicationContainer = getWebAppContainer(services);
    
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
    
    
            RecurringJob.AddOrUpdate<IScheduledTaskManager>(task => task.ProcessDailyJob(), Cron.Daily);
    
            //app.UseMvc...
            //...other code
        }
    
        //...other code
    }
