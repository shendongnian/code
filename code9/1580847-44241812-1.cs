    public class Startup {    
        public IContainer ApplicationContainer { get; private set; }
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            // Configures Hangfire with the following methods exposed on 
            // the IGlobalConfiguration interface, and registers all the
            // required classes, including logging and DI, using new DI 
            // abstraction.
            services.AddHangfire(x => x.UseSqlServerStorage("<connection string>"));
    
            // Adding service for daily job 
            services.AddTransient<IDailyService, SimpleDailyService>()
    
            this.ApplicationContainer = getWebAppContainer(services);
    
            return new AutofacServiceProvider(this.ApplicationContainer);
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
    
    
            RecurringJob.AddOrUpdate<IDailyService>(task => task.DailyJob(), Cron.Daily);
    
            //app.UseMvc...
            //...other code
        }
    
        //...other code
    }
