    public class MyDbContext : DbContext
    {
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            
            CheckDisposed();
            TryDetectChanges();
            
            //remove try catch to throw without logging.
            return await StateManager.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
