    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
     
        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }
    
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
