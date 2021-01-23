MyContext.cs
 
    public class MyContext : DbContext
    {
        public MyContext() : base(“name=MyContextConn”)
        {
        }
     
          public DbSet<Blog> Blogs { get; set; }
    }
