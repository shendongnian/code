    public class Extensions
    {
        private static ApplicationDbContext _dbContext { get; set; }
    
        public static void Init(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
