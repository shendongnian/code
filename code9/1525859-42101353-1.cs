    public class MailingContext : DbContext
    {
        public MailingContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Mail> Mails { get; set; }
        public DbSet<File> Files { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
