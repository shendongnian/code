    internal class ContentEntityRefConfiguration : EntityTypeConfiguration<ContentEntityRef>, IEntityConfiguration
    {
        public ContentEntityRefConfiguration()
        {
            this.HasKey(x => x.EntityId).Property(t => t.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.EntityName).IsRequired().HasMaxLength(50);
            
            this.HasMany(c => c.Children).WithOptional(c => c.Parent).HasForeignKey(c => c.ParentEntityId);
            this.HasMany<RoleRef>(role => role.RoleRefs)
               .WithMany(content => content.ContentEntities)
               .Map(contentRole =>
               {
                   contentRole.MapLeftKey("EntityID");
                   contentRole.MapRightKey("RoleID");
                   contentRole.ToTable("RoleEntityMap");
               });
        }
    }
