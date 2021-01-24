    class Student
    {
        public int Id {get; set;}             // primary Key
        public DateTime Birthday {get; set;
        public string FirstName {get; set;}
        ...                                   // other properties
    }
    class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;} // the table you want to update
        ...                                        // other tables
    }
