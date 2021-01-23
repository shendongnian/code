    public class EntityConfiguration<TEntityType> : EntityTypeConfiguration<TEntityType> where TEntityType : Entity
    {
      public EntityConfiguration()
      {
        HasKey(p => p.Id);
        Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        Property(p => p.TimeStamp).IsRowVersion();
      }
    }
