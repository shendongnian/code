    class DbContextA : DbContext
    {
        public DbSet<Person> Persons {get; set;}
        ...
    }
    class DbContextB : DbContext
    {
        public DbSet<Address> Addresses {get; set;}
        ...
    }
