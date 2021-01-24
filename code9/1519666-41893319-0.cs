    public class DatabaseContext : DbContext
    {
    	public DatabaseContext(): base(YourWebConfigConnectionStringName){}
    	public DbSet<Client_ClientDepartment> ClientDepartment { get; set; }
    	public DbSet<Client_ClientDesignation> ClientDesignation { get; set; }
