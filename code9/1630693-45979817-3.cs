    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseSqlServer(connectionString,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MyDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new MyDbContext(builder.Options);
        }
    }
