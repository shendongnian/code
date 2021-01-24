    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddOData();
            services.AddMvc();
 
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Adding Model class to OData
            var builder = GetEdmModel(app.ApplicationServices);
            builder.EntitySet<Person>(nameof(Person));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc((routebuilder =>
            {
                routebuilder.MapODataServiceRoute("odata","odata", builder.GetEdmModel());
            }));
        }
        private static ODataConventionModelBuilder GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);
           
          return builder;
        }
    }
