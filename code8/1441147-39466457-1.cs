    namespace WebApplication1
    {
        public class App1Context : BaseDbContext
        {
            public DbSet<Country> Countries { get; set; }
        }
    
        public class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ApplicationUserId { get; set; }
            public ApplicationUser ApplicationUser { get; set; }
        }
    }
