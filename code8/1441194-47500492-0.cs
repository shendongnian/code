    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>()
            .Property<string>("TenantId")
            .HasField("_tenantId")
            //.Metadata.IsReadOnlyAfterSave = true;
            .Metadata.AfterSaveBehavior = Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore;
    }
