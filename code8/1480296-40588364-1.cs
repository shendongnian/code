        public override int SaveChanges()
        {
            var timestamp = DateTime.Now;
            // First look at new items these will only be tracked
            var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added).Select(x => x.Entity);
            foreach (var addition in addedEntities)
            {
                var entity = addition as TrackedEntity;
                if (entity != null)
                {
                    entity.CreatedDate = timestamp;
                    entity.ModifiedDate = timestamp;
                    entity.ModifiedBy = _loggedOnUser;
                }
            }
            // Next look at modified entries
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Deleted);
            foreach (var update in modifiedEntities)
            {
                // Only check tracked entities if modified
                if (update.State == EntityState.Modified)
                {
                    var tracked = update.Entity as TrackedEntity;
                    if (tracked != null)
                    {
                        tracked.ModifiedDate = timestamp;
                        tracked.ModifiedBy = _loggedOnUser;
                    }
                }
            }
       }
