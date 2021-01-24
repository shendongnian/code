    public class Person : IAddress
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public virtual City City { get; set; }
        [NotMapped]
        public IAddress Address { get { return this; } }
    }
    
    public interface IAddress
    {
        string Province { get; set; }
        City City { get; set; }
    }
    public class City
    {
        public Int32 CityID { get; set; }
        public string Name { get; set; }
    }
    public class MappingContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(t => t.PersonID)
                .HasOptional(t => t.City)
                .WithMany()
                .Map(t => t.MapKey("CityID"));
            modelBuilder.Entity<Person>().ToTable("TB_PERSON");
            modelBuilder.Entity<City>()
                .HasKey(t => t.CityID)
                .ToTable("City");
        }
    }
