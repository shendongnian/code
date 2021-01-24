     public class TwitterContext : DbContext
    {
        //Added this Code with the connection string
        public TwitterContext() : base(@"Integrated Security=true;server=MYNAME-PC\SQLEXPRESS;database=TwitterDatabase")
    {
            //Disable initializer
            Database.SetInitializer<TwitterContext>(null);
        }
        public DbSet<TwitterUser> User { get; set; }
        public DbSet<TwitterUserData> UserData { get; set; }
    }
