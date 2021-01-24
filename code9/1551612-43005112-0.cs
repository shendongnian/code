    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            HasOptional(x => x.User).WithMany(x => x.Addresses).Map(x => x.MapKey("User_Id"));
        }
    }
