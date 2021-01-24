    public class DataService
    {
        private readonly DataContext _context;
    
        public DataService(DataContext context)
        {
            _context = context;
        }
    
        public IQueryable<EntityType> EntityTypes => _context.EntityTypes.Where(t => t.Something == true);
    }
