    public abstract class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : Entity 
    {
      protected BaseEntityConfiguration()
      {
          HasKey(p => p.Id);
          Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
          Property(p => p.TimeStamp).IsRowVersion();
      }
    }
        
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {}
