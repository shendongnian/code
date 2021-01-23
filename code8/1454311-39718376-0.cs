    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Other code...
    
            // This is wrong!
            this.HasReguired(c => c.Address).WithMany(a => a.Customers);
            // This is right!
            this.HasOptional(c => c.Address).WithMany(a => a.Customers); 
        }
    }
