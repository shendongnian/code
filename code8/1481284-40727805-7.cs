    modelBuilder.Entity<Test>().HasKey(a => a.ID);
    modelBuilder.Entity<Test>().Property(s => s.DateDef).HasDefaultValueSql("GETDATE()");
    modelBuilder.Entity<Test>().Property(s => s.IntDef).HasDefaultValueSql("1");
    modelBuilder.Entity<Test>().Property(s => s.BoolDef).HasDefaultValue(true);
    // Equivalent:
    // modelBuilder.Entity<Test>().Property(s => s.BoolDef).HasDefaultValueSql("1");
