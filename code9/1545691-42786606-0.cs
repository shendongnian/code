    modelBuilder.Types<IAuditable>().Configure(e =>
    {
        e.Property(Auditable.CreatedBy).HasMaxLength(50).IsRequired();
        e.Property(Auditable.UpdatedBy).HasMaxLength(50).IsRequired();
        e.Property(Auditable.CreatedOn).IsRequired();
        e.Property(Auditable.UpdatedOn).IsRequired();
    });
