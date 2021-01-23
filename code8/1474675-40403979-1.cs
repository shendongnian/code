        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                var saveEntity = entity.Entity as ISavingChanges;
                saveEntity.OnSavingChanges();
            }
            return base.SaveChanges();
        }
