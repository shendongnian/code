    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        AmpContext IDesignTimeDbContextFactory<MyContext>.CreateDbContext(string[] args)
        {
            var connectionString = ConfigHelper.GetConnectionString();
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new AmpContext(optionsBuilder.Options);
        }
    }
