    public class Login
    {
        public int Id {get; set;}
        public string UserName {get; set;}
        public string Password {get; set;}
    }
    public class MyDbContext : DbContext
    {
        public DbSet<Login> Logins {get; set;}
    }
