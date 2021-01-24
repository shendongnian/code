    public class MyContext : DbContext
    {
        public MyContext():base("myConnectionStringName")
        {
        }
    }
