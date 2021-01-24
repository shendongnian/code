        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<RecipeDbContext >(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringName")));
        }
