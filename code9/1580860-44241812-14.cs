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
    
        public void Configuration(IApplicationBuilder app) {
            // app.AddLogger...
               
            //add hangfire features
            app.UseHangfireServer();
            app.UseHangfireDashboard();
    
            //Add the recurring job
            RecurringJob.AddOrUpdate<IScheduledTaskManager>(task => task.ProcessDailyJob(), Cron.Daily);
    
            //app.UseMvc...
            //...other code
        }
        public IServiceProvider ConfigureServices(IServiceCollection services) {    
            // Adding custom services
            services.AddTransient<IScheduledTaskManager, ScheduledTaskManageImplementation>();
            //add other dependencies...
            
            // add hangfire services
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
    
        //...other code
    }
