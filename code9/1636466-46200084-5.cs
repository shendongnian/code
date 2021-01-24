    class MyDbcontext : Dbcontext
    {
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
        public IQueryable<Person> Persons
        {
            get
            {
                return this.Teachers.Cast<Person>()
                .Concat(this.Students.Cast<Person>());
            }
        }
    }
    
