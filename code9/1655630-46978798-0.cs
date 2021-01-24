    public class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase>
        where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
        {
            //Base Configuration
        }
    }
    public class MaintainerConfiguration : BaseEntityTypeConfiguration<Maintainer>
    {
        public override void Configure(EntityTypeBuilder<Maintainer> entityTypeBuilder)
        {
            entityTypeBuilder.Property(b => b.CreatedDateUtc).HasDefaultValueSql("CURRENT_TIMESTAMP");
            base.Configure(entityTypeBuilder);
        }
    }
