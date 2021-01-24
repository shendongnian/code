        public void ConfigureServices(IServiceCollection services)
        {
           string connectionString = "my connection string";
           services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<ConfigurationDbContext>(options => 
                    options.UseSqlServer(connectionString));
      
            //Add more services here e.g.
            services.AddMvc();
        }
