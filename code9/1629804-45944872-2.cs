    class BaseConfiguration : IEntityTypeConfiguration<TBaseModel>
    {
            public void Configure(EntityTypeBuilder<TBaseModel> builder)
            {
                builder.Property...
            }
    }
    class ModelConfiguration : BaseConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
             base.Configure(builder)
             ...// model specific stuff
        }
    }
    class DbContext
    {
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfiguration(new ModelConfiguration());
            }
    }
