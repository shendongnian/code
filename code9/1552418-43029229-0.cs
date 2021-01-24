    public partial class YourEntities : DbContext
    {
        public override int SaveChanges()
        {
            var Class1 = ChangeTracker.Entries().Where(
                e => e.State == EntityState.Added &&
                     e.Entity is Class1);
            // Class1.Class2.Id // your logic ...
    
            return base.SaveChanges();
        }
    }
