    // required when local database deleted
    public class ToDoContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppContext>();
              builder.UseSqlServer("Server=localhost;Database=DbName;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AppContext(builder.Options);
        }
    }
