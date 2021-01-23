    public class ApplicationContext : DbContext
    {
        /* ... */
        public override int SaveChanges()
        {
            TrackModifiedDates();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync()
        {
            TrackModifiedDates();
            return await base.SaveChangesAsync();
        }
        private void TrackModifiedDates()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is IEntityRoot && (x.State == EntityState.Added));
            //if anonymous access is possible, do a null check here.
            var userName = HttpContext.Current.User.Identity.Name
 
            foreach (var entity in entities)
            {
                ((IEntityRoot)entity.Entity).Created = DateTime.UtcNow;
                ((IEntityRoot)entity.Entity).CreatedBy = userName;
                
            }
        }
    }
