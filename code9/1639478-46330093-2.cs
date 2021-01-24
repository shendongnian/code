    modelBuilder.Entity<Table3>()
        .HasKey(t3 => new { t3.Table1Code, t3.Table2Code });
    modelBuilder.Entity<Table1_Table2>()
        .HasOptional(t => t.Table3)
        .WithRequired(t3 => t3.Table1_Table2);
