    public class TransactionPerRequestMiddleware
    {
        private readonly RequestDelegate next_;
    
        public TransactionPerRequestMiddleware(RequestDelegate next)
        {
            next_ = next;
        }
    
        public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
        {
            var transaction = dbContext.Database.BeginTransaction(
                System.Data.IsolationLevel.ReadCommitted);
    
            await next_.Invoke(context);
    
            if (context.Response.StatusCode == 200)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
    }
