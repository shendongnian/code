    public class MyContext : DbContext
    {
        //...
        public override int SaveChanges()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries<Asset>()
                                                       .Where(t => t.State == EntityState.Added))
            {
                dbEntityEntry.Entity.Id = default(int);
            }
            return base.SaveChanges();
        }
    }
