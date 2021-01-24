        public void ConfigureServices(IServiceCollection services)
        {
			...
            #region PostgreSQL
            var sqlConnectionString = Configuration.GetConnectionString("your connection string name");
            // Use a PostgreSQL database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("Your.Assembly.Name")
                )
            );
            #endregion
			
			...
        }
