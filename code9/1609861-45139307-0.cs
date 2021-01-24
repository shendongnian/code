    public partial class EfEntities
    {
        public override int SaveChanges()
        {
            var changes = from e in this.ChangeTracker.Entries()
                          where e.State != System.Data.Entity.EntityState.Unchanged
                          select e;
            foreach (var change in changes)
            {
                if (change.State == System.Data.Entity.EntityState.Added)
                {
                    // Handle added entities
                }
                else if (change.State == System.Data.Entity.EntityState.Modified)
                {
                    // Handle modified entities
                }
                else if (change.State == System.Data.Entity.EntityState.Deleted)
                {
                    // Handle deleted entities
                }
            }
            return base.SaveChanges();
        }
    }
