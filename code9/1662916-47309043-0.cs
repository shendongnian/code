    public class PeopleContext : DbContext
    {
        public PeopleContext() : base("Database") //it makes reference to the connection string defined in the app.config
        {     
        }
        public IDbSet<Person> People { get; set; }
    }
