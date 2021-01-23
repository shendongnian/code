    public abstract class IEntityMap<T> : EntityTypeConfiguration<T> where T : class, IEntity
    {
        protected IEntityMap()
        {
            this.Property(x => x.PropertyA);
            this.Property(x => x.PropertyB);
        }
    }
