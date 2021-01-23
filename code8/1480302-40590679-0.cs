        public override int SaveChanges()
        {
            var timeStamp = DateTime.UtcNow;
            var userId = this.GetAuthenticatedUser();
            this.HandleAddedEntities(userId, timeStamp);
            this.HandleModifiedEntities(userId, timeStamp);
            return base.SaveChanges();
        }
        private void HandleAddedEntities(Guid userId, DateTime timeStamp)
        {
            var entities = ChangeTracker.Entries()
                            .Where(x => x.Entity is IAddedEntity && 
                                        x.State == EntityState.Added)
                            .Select(x => x.Entity as IAddedEntity);
            foreach (var e in entities)
            {
                e.CreatedById = userId;
                e.CreatedOn = timeStamp;
            }
        }
        private void HandleModifiedEntities(Guid userId, DateTime timeStamp)
        {
            var entities = ChangeTracker.Entries()
                             .Where(x => x.Entity is IModifiedEntity && 
                                         (x.State == EntityState.Added || 
                                          x.State == EntityState.Modified))
                             .Select(x => x.Entity as IModifiedEntity);
            foreach (var e in entities)
            {
                e.ModifiedById = userId;
                e.ModifiedOn = timeStamp;
            }
        }
