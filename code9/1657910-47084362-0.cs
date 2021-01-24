    class Customer
    {
        public int Id {get; set;} // primary key
        // a Customer has zero or more Assignments
        public virtual ICollection<Assignment> Assignments {get; set;}
        public int Nbr {get; set;}
        ... // other properties
    }
    class Assignment
    {
        public int Id {get; set;} // primary key
        // every Assignment belongs to one Customer via foreign key
        public int CustomerId {get; set;}
        public virtual Customer Customer {get; set;}
        public DateTime AssignmentTime {get; set;}
        ... // other properties
    }
    public MyDbContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Assignment> Assignments {get; set;}
    }
