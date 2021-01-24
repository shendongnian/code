    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        public ITripPictureRepository TripsRepository{ get; }
    
        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
            Trips = new Repository<Trip>(_context.Trips)
        }
    
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
