    public class ItemService 
    {
        private readonly ApplicationContext _context;
    
        public ItemService(ApplicationContext context)
        {
            _context = context;
        }
    
        public void Add(Item item)
        {
            // A paramatized query of some sort to prevent sql injection
            // see https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/advanced
            var parameters = new List<object>();
            _context.Database.ExecuteSqlCommand("", parameters);
        }
    }
