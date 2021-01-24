    public class MyContext : DbContext
    {
    
    	public DbSet<User> Users { get; set; }
    	public DbSet<Folder> Folders { get; set; }
    }
