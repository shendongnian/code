        public void ConfigureServices(IServiceCollection services)
        {
            //Configure DB connection strings
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MyDbEF")));
            // Add framework services.
            services.AddMvc();
        }
