    public class MyIdentityStore :
        IUserClaimStore<IdentityUser>
    {
        private MyDbContext _myDbContext;
        private bool _disposed = false; 
        public MyIdentityStore(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        #region IUserClaimStore
        public Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            // logic here to retrieve claims from my own database using _myDbContext
        }
        // All other methods from interface throwing System.NotSupportedException.
        #endregion
        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        { /* do cleanup */ }
        #endregion
    }
