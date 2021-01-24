    public class MyDbContext : DbContext
    {
        public static Func<string> ConnectionStringProvider = () => "TheNameOfTheConnectionString";        
        
        public MyDbContext() : base(ConnectionStringProvider())
        
        //....
    }
