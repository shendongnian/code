    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public virtual PersonAddress Address { get; set; }
    }
    
    public class Address
    {
        public string Province { get; set; }
        public virtual City City { get; set; }
    }
    public class PersonAddress : Address
    {
        public Int32 PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
    public class CustomerAddress : Address
    {
        public Int32 CustomerID { get; set; }
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public virtual CustomerAddress Address { get; set; }
    }
    public class City
    {
        public Int32 CityID { get; set; }
        public string Name { get; set; }
    }
    public class MappingContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PersonAddress> PersonAddresses { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonAddress>()
                .HasKey(t => t.PersonID)
                .HasOptional(t => t.City)
                .WithMany()
                .Map(t => t.MapKey("CityID"));
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(t => t.CustomerID)
                .HasOptional(t => t.City)
                .WithMany()
                .Map(t => t.MapKey("CityID"));
            modelBuilder.Entity<Person>()
                .HasRequired(t => t.Address)
                .WithRequiredPrincipal(t => t.Person);
            modelBuilder.Entity<Customer>()
                .HasRequired(t => t.Address)
                .WithRequiredPrincipal();
            modelBuilder.Entity<Person>().ToTable("TB_PERSON");
            modelBuilder.Entity<PersonAddress>().ToTable("TB_PERSON");
            modelBuilder.Entity<Customer>().ToTable("TB_CUSTOMER");
            modelBuilder.Entity<CustomerAddress>().ToTable("TB_CUSTOMER");
            modelBuilder.Entity<City>()
                .HasKey(t => t.CityID)
                .ToTable("City");
        }
    }
