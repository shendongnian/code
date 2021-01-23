    public class CustomerConfiguration: EntityTypeConfiguration<Customer>;
    {
 
        public CustomerConfiguration(): base()
        {
 
        HasKey(p => p.Id);
        Property(p => p.Id).
            HasColumnName("Id").
            HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
            IsRequired();
        Property(p => p.dtUpdated).
            HasColumnName("EntryTs").
            IsRequired();
        ToTable("Customers");
        }
 
    }
