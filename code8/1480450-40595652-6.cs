    modelBuilder.Entity<Parent>().ToTable("A_PARENT");
    modelBuilder.Entity<Parent>().Property(e => e.Id).HasColumnName("A_PAR_ParentId");
    modelBuilder.Entity<Parent>().HasKey(e => e.Id);
    modelBuilder.Entity<Parent>().Property(e => e.Data).HasColumnName("A_PAR_Data");
    
    modelBuilder.Entity<Child>().ToTable("B_CHILD");
    modelBuilder.Entity<Child>().Property(e => e.Id).HasColumnName("B_CHL_ChildId");
    modelBuilder.Entity<Child>().HasKey(e => e.Id);
    modelBuilder.Entity<Child>().Property(e => e.ChildData).HasColumnName("B_CHL_ChildData");
