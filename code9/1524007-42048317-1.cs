    protected override void OnModelCreating(ModelBuilder modelBuilder)
        modelBuilder.Entity<Foo>()
            .Property(i => i.Created)
            .HasDefaultValueSql("getdate()");
    
        modelBuilder.Entity<Foo>()
            .Property(i => i.LastUpdated)
            .HasDefaultValueSql("getdate()");
    }
