    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
    }
    
    public class Address
    {
        public Int32 ID { get; set; }
        public string Province { get; set; }
        public virtual City City { get; set; }
    }
    public class City
    {
        public Int32 CityID { get; set; }
        public string Name { get; set; }
    }
    public class MappingContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(t => t.ID)
                .HasOptional(t => t.City)
                .WithMany()
                .Map(t => t.MapKey("CityID"));
            modelBuilder.Entity<Address>()
                .Property(t => t.ID)
                .HasColumnName("PersonID");
            modelBuilder.Entity<Person>()
                .HasKey(t => t.PersonID)
                .HasRequired(t => t.Address)
                .WithRequiredPrincipal();
            
            modelBuilder.Entity<Person>().ToTable("TB_PERSON");
            modelBuilder.Entity<Address>().ToTable("TB_PERSON");
            modelBuilder.Entity<City>()
                .HasKey(t => t.CityID)
                .ToTable("City");
        }
    }
