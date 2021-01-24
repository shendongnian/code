    public class myContext : DbContext
    {
        public myContext() : base(statProps.ConnectionString) { }
        //all my DbSets e.g.
        public DbSet<Person> Persons{ get; set; }
        
    }
