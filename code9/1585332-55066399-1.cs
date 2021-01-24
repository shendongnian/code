        public void ConfigureServices(IServiceCollection services)
        {
            var myDbContextAssemblyName = typeof(MyDbContext).Assembly.GetName().Name;
            var connectionString = Configuration.GetConnectionString(MyDbContext.ConnectionStringName);
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly(myDbContextAssemblyName)));
                // do more ...
            }
