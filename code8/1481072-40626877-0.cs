    public interface ITransactionDealerRepository
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void DisposeTransaction();
    }
    public sealed class TransactionDealerRepository : BaseEntityFrameworkRepository, ITransactionDealerRepository
    {
        public TransactionDealerRepository(MyDBContext dbContext)
           : base(dbContext)
        { }
        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }
        public void DisposeTransaction()
        {
            _dbContext.Database.CurrentTransaction.Dispose();
        }
    }
