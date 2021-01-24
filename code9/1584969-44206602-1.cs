    public interface ITentantDbContextFactory<T>
    {
        T Create(string tenantId);
    }
    public class AppTenantDbContextFactory : ITenantDbContextFactory<AppDbContext>
    {
        public AppDbContext Create(string tenantId) 
        {
            // do some validations on tenantId to prevent users from 
            // injecting arbitrary strings into the connection string 
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            // you can also load it from an injected option class
            builder.UseSqlServer($"Server=MYSERVERHERE;Database={tenantId};Trusted_Connection=True;");
            return new AppDbContext(builder.Options);
        }
    }
