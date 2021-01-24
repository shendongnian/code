    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) {
            _context =  context;
        }
    
        //...other code removed for brevity
    }
