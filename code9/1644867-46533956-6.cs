    public PermissionForMap()
    {
        this.ToTable("PermissionForm").HasKey(p => p.Id);
    
        this.Property(p => p.Name).HasColumnName("Name").HasMaxLength(30);
        this.Property(p => p.Permissions).HasColumnName("Permissions"); // this is redundant, it's just to replicate your behavior
    }
