    public class MyDbContext : IdentityDbContext<MyUser>
    {
       public MyDbContext(string connectionString) : base(connectionString)
       {
       }
    }
