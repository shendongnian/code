    if (!IsInMemoryContext)
    {
        modelBuilder.Entity<AuditLog>()
            .Property(e => e.EventType)
            .HasColumnType("char");
    }
