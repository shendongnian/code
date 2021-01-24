        public override int SaveChanges()
        {
            PhysicalAttributes.Load();
            var entryGroup = from entry in ChangeTracker.Entries<PhysicalAttribute>()
                          group entry by new { entry.Entity.Description, entry.Entity.Type } into byKey
                          where byKey.Any( e => e.State == EntityState.Unchanged)
                          select byKey;
            foreach (var eg in entryGroup)
            {
                foreach (var e in eg )
                {
                    if (e.State == EntityState.Added)
                    {
                        e.State = EntityState.Detached;
                    }
                }
            }
            return base.SaveChanges();
        }
