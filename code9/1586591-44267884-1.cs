    public class GenericDbContext : DbContext
    {
    	public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }
    
    	protected override void OnModelCreating(ModelBuilder builder)
    	{
    		builder.Entity<Models.Mailer.Address>().ToTable("MailerAddresses");
    	}
    
    	public DbSet<Client> Clients { get; set; }
    	public DbSet<Models.Mailer.Address> MailerAddresses { get; set; }
    }
