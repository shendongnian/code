    public abstract class BaseEntityFrameworkNonTransactionRepository<T> where T : DbContext, new()
    {
        protected T _context;
        protected BaseEntityFrameworkNonTransactionRepository()
        {
            _context = new T();
            ((IObjectContextAdapter)_context).ObjectContext.ContextOptions.EnsureTransactionsForFunctionsAndCommands = false;
        }
    }
