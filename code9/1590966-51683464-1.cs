     public class DesignTimeActivitiesDbContextFactory : IDesignTimeDbContextFactory<ActivitiesDbContext>
        {
            public ActivitiesDbContext CreateDbContext(string[] args)
            {
                DbContextOptionsBuilder<ActivitiesDbContext> builder = new DbContextOptionsBuilder<ActivitiesDbContext>();
    
                var context = new ActivitiesDbContext(
                    builder
                    .UseSqlServer("Data Source=(local);Initial Catalog=Activities;Integrated Security=False;User ID=user;Password=pw;Connect Timeout=30;Encrypt=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;")
                    .Options);
    
                return context;
            }
        }
