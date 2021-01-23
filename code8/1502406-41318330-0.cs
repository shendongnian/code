    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Corporation
    {
        public int CorporationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Context : DbContext
    {
        public Context() : base("name=codefirst")
        {
    
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Corporation> FooBar { get; set; }
    }
