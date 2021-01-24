    public partial class TBCompanyEntities
    {
     
        public override void SaveChanges()
        {
           //TODO: Here you will have to detect which entity has been modified/updated.
           // This should be possible, by using the Track Entity Changes features
                   var modifiedEntities = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified).ToList();
            base.SaveChanges();
        }
    }
