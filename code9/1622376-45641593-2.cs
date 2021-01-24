    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
