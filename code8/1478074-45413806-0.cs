    public static EntityTypeBuilder<Project> Map(this EntityTypeBuilder<Project> cfg)
    {
        cfg.ToTable("sql_Projects");
        // Primary Key
        cfg.HasKey(p => p.Id);
        cfg.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("ProjectId");
        return cfg;
    }
