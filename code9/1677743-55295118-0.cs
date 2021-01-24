    publicclass NoConcurencyDbContext : MainDbContext {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EntityWithRowVersio>().Property(t => t.RowVersion).IsConcurrencyToken(false);
        }
    }
