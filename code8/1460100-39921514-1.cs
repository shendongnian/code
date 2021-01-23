    using Support.Repositories.Contracts;
    using System.Data.Entity;
    
    namespace Support.Entity.Repositories
    {
        public class EntityDatabaseTransaction : IDatabaseTransaction
        {
            private DbContextTransaction _transaction;
    
            public EntityDatabaseTransaction(DbContext context)
            {
                _transaction = context.Database.BeginTransaction();
            }
    
            public void Commit()
            {
                _transaction.Commit();
            }
    
            public void Rollback()
            {
                _transaction.Rollback();
            }
    
            public void Dispose()
            {
                _transaction.Dispose();
            }
        }
    }
