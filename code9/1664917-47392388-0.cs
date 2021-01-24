        public class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T> where T : class, IEntity
        {
            private bool BIgnoreBaseProps = true;
    
            public EntityTypeConfigurationBase(bool bIgnoreBaseProps = true) : base()
            {
                BIgnoreBaseProps = bIgnoreBaseProps;
            }
    
            public void Configure(EntityTypeBuilder<T> builder)
            {
                if (BIgnoreBaseProps)
                {
                    builder.Ignore(x => x.State);
                    builder.Ignore(x => x.AssociationState);
                }
            }
        }
