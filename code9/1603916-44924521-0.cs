    private static void BasisFields<T>(DbModelBuilder modelBuilder)
        where T : BaseEntity
    {
        modelBuilder.Entity<T>()
            .Property(k => k.CreatedUser)
            .HasMaxLength(32)
            .HasColumnType("varchar");
    
        modelBuilder.Entitity<T>()
            .Property(k => k.CreatedDate)
            .HasColumnType("datetime");
    
        modelBuilder.Entity<T>()
            .Property(k => k.ChangedUser)
            .HasMaxLength(32)
            .HasColumnType("varchar");
    
        modelBuilder.Entity<T>()
            .Property(k => k.ChangedDate)
            .HasColumnType("datetime");    
    }
