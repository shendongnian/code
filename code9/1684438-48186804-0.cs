    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, 
                                        ApplicationRole, string>
    {
        //The context class constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //the models that you are using
        public DbSet<ModelExampleClass> ModelExampleClasses { get; set; }
    }
