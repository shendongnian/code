    public class Repository
    {
        private readonly SkinDbContext dbContext; 
        public Repository(Settings settings)
        {
            dbContext = new MyDbContext(settings.DBConnection);
        }
