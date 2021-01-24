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
                    var item = change.Cast<IEntity>().Entity;
                    var originalValues = this.Entry(item).OriginalValues;
                    var currentValues = this.Entry(item).CurrentValues;
                    foreach (string propertyName in originalValues.PropertyNames)
                    {
                        var original = originalValues[propertyName];
                        var current = currentValues[propertyName];
                        if (!Equals(original, current))
                        {
                            // log propertyName: original --> current
                        }
                    }
                }
                else if (change.State == System.Data.Entity.EntityState.Deleted)
                {
                    // Handle deleted entities
                }
            }
            return base.SaveChanges();
        }
    }
