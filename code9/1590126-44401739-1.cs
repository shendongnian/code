    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table2>() 
            .Property(t => t.Table1Id) 
            .HasColumnName("Table1_ID");
    }
