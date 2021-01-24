    internal abstract class TenantEntityConfigurationBase<TEntity, TKey> :
        EntityConfigurationBase<TEntity, TKey>
        where TEntity : TenantEntityBase<TKey>
        where TKey : IEquatable<TKey> {
        protected readonly TenantDbContext Context;
    
        protected TenantEntityConfigurationBase(
            string table,
            string schema,
            TenantDbContext context) :
            base(table, schema) {
            Context = context;
        }
    
        protected override void ConfigureFilters(
            EntityTypeBuilder<TEntity> builder) {
            base.ConfigureFilters(builder);
    
            builder.HasQueryFilter(
                e => e.TenantId == Context.TenantId);
        }
    
        protected override void ConfigureRelationships(
            EntityTypeBuilder<TEntity> builder) {
            base.ConfigureRelationships(builder);
    
            builder.HasOne(
                t => t.Tenant).WithMany().HasForeignKey(
                k => k.TenantId);
        }
    }
