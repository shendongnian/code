    public class AuthorizationContext : DbContext
    {
        static AuthorizationContext()
        {
             QueryFilterManager.Filter<Orders>(q => q.Where(x => x.Price <= 5000));
        }
        public AuthorizationContext()
        {
             QueryFilterManager.InitilizeGlobalFilter(this);
        }
    }
