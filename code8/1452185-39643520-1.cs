    protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Foo>()
                    .HasOptional(cpi => cpi.Bar)
                    .WithRequired(api => api.Foo);
        // needed
        modelBuilder.Entity<Bar>()
          .HasKey(b => b.Id)
          .Property(b => b.Id)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
