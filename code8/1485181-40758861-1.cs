    public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddDbContext<TestDbContext>(options =>
               options.UseSqlServer(Configuration["Data:UCASAppDatabase:ConnectionString"]));
            services.AddMvc();
        }
