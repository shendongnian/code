    public class CountryConfiguration : EntityConfiguration<Country>
    {
      public CountryConfiguration() : base()
      {
        Property(p => p.Name).IsRequired().HasMaxLength(100);
        Property(p => p.InternationalCode).IsRequired().HasMaxLength(5);
      }
    }
