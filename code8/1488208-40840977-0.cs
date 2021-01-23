    public class DbUnitOfWork : IUnitOfWork
        {
            private readonly MyDbContext _context;
    
            public DbUnitOfWork()
            {
                _context = new MyDbContext();
            }
    
            public void Dispose()
            {
                _context.Dispose();
            }
    
            public void Commit()
            {
                try
                {
                   _context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    throw exception;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            public Task CommitAsync()
            {
    
                try
                {
                    return _context.SaveChangesAsync();
                }
                catch (DbEntityValidationException exception)
                {
                    throw exception;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    
               
            }
    
            public Task CommitAsync(CancellationToken cancellationToken)
            {
                return _context.SaveChangesAsync(cancellationToken);
            }
    
            internal DbSet<T> Set<T>() where T : Entity
            {
                return _context.Set<T>();
            }
        }
