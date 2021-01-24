    public partial class MyContext : DbContext
    {
        public MyContext() : base("name=MyDbName")
        {
        }
        public MyContext(string connectionString) : base(connectionString)
        {
        }
    
        // Class members
    }
