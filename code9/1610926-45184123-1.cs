    class NewDbContext : DbContext
    {
        ...
        public override int SaveChanges()
        {
            GenerateIds();
            base.SaveChanges();            
        }
        private void GenerateIds()
        {
            foreach (var addedEntry in this.ChangeTracker.Entries
                .Where(entry => entry.State == EntityState.Added))
            {
                ((IID)addedEntity).Id = idGenerator.CreateId();
            }
        }
    }
