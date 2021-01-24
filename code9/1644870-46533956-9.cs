    public class PermissionForMap : EntityTypeConfiguration<PermissionForm>
    {
        public PermissionForMap()
        {
            this.ToTable("PermissionForm").HasKey(p => p.Id);
        
            this.Property(p => p.Name).HasColumnName("Name").HasMaxLength(30);
            this.HasMany(p => p.Permissions) 
                .WithRequired(e => e.PermissionForm)
                .HasForeignKey(e => e.PermissionFormId);
        }
    }
    public class PermissionEntityMap : EntityTypeConfiguration<PermissionEntity>
    {
        public PermissionEntityMap()
        {
            ToTable("PermissionEntities")
                .HasKey(e => new { e.PermissionFormId, e.PermissionItem }):
        }
    }
 
