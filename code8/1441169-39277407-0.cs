         public class ModelRepository
         {
            private readonly ApplicationDbContext _context;
    
            public ModelRepository(ApplicationDbContext context)
            {
                _context = context;
            }
    
            public async Task Save(MyModel model)
            {
                // Do something with _context;
            }
        }
