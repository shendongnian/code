    modelBuilder.Types<BaseEntity>().Configure(c =>
    {
        c.Property(k => k.CreatedUser)
            .HasMaxLength(32)
            .HasColumnType("varchar");
    
        c.Property(k => k.CreatedDate)
            .HasColumnType("datetime");
    
        c.Property(k => k.ChangedUser)
            .HasMaxLength(32)
            .HasColumnType("varchar");
    
        c.Property(k => k.ChangedDate)
            .HasColumnType("datetime");    
    });
