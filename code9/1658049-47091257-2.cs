    class Owner
    {
        public int Id {get; set;}
        // every Owner has zero or more Pets:
        public virtual ICollection<Pet> Pets {get; set;}
        ... // other properties
    }
    class Pet
    {
        public int Id {get; set;}
        // every Pet belongs to exactly one Owner, using foreign key:
        public int OwnerId {get; set;}
        public Owner Owner {get; set;}
    }
    class MyDbConnection : DbConnection
    {
        public DbSet<Owner> Owners {get; set;}
        public DbSet<Pet> Pets {get; set;}
    }
