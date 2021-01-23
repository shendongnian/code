     public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
        {
    
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
            public ApplicationDbContext()
                : base()
            {
            }
    
            public virtual IEnumerable<Provider> Providers
            {
                get
                {
                    return (IEnumerable<Provider>)Users.Where(z => z.Type == UserTypes.Provider).AsEnumerable();
                }
            }
