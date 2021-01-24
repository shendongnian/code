    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext()
        {
        }
        public void SetConstraint<T>(Func<IQueryable<T>, IQueryable<T>> constraint) 
            where T : class
        {
            this.Filter<TEntity>(constraint);
        }    
    }
