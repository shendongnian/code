    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Configure domain classes using modelBuilder here
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>()
                    .Property(p => p.CountryName)
                    .HasMaxLength(40);
    }
