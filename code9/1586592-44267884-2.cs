    public class MailerDbContext : DbContext
    {
    	public MailerDbContext(DbContextOptions<MailerDbContext> options, GenericDbContext generic) : base(options)
    	{
    		this.GenericDbContext = generic;
    	}
    
    	public GenericDbContext GenericDbContext { get; set; }
    }
