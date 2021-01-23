    using App.Contexts;
    using App.Repositories.Contracts;
    using App.Repositories.Entity;
    using Support.Repositories;
    
    
    namespace App.Repositories
    {
        public class UnitOfWork : IUnitOfWork
        {
            private readonly AppContext _context;
            public IUserRepository  Users { get; private set; }
            public IAddressRepository Addresses { get; private set; }
    
            public UnitOfWork(AppContext context)
            {
                _context = context;
    
                Users = new UserRepository(_context);
                Addresses = new AddressRepository(_context);
            }
    
            public UnitOfWork() : this(new AppContext())
            {
            }
    
            public int Save()
            {
                return _context.SaveChanges();
            }
    
            public void Dispose()
            {
                _context.Dispose();
            }
    
            public IDatabaseTransaction BeginTransaction()
            {
                return new EntityDatabaseTransaction(_context);
            }
        }
    }
