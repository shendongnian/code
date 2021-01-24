    class BaseConfiguration<TBaseModel> : IEntityTypeConfiguration<TBaseModel>
    {
        public virtual void Configure(EntityTypeBuilder<TBaseModel> builder)
        {
            builder.Property...
        }
    }
    class ModelConfiguration : BaseConfiguration<Model>
    {
        public override void Configure(EntityTypeBuilder<Model> builder)
        {
             base.Configure(builder)
             ...// model specific stuff
        }
    }
    class CustomDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
        }
    }
