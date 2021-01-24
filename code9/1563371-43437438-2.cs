    public partial class PostalDbContext
    {
        public override int SaveChanges()
        {
            DateTime time = DateTime.Now;
            var entries = ChangeTracker.Entries()
                .Where(entry => entry.Entity is ITrackableEntity)
                .ToList();
            ITrackableEntity x;
            foreach (var entry in entries.Where(e => e.State == EntityState.Added))
            {
                entry.SetPropertyValue(nameof(x.DateCreated), time);
            }
            foreach (var entry in entries.Where(e => e.State == EntityState.Modified))
            {
                entry.SetPropertyValue(nameof(x.DateModified), time);
            }
            return base.SaveChanges();
        }
    }
    public static class DbEntityEntryEx
    {
        public static void SetPropertyValue<T>(this DbEntityEntry entry, string propertyName, T time)
        {
            entry.Property(propertyName).CurrentValue = time;
        }
    }
