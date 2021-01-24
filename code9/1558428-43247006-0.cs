    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Configure Column
        modelBuilder.Entity<EntityClass>()
                    .Property(p => p.CreatedAt)
                    .HasColumnOrder(0);
    }
