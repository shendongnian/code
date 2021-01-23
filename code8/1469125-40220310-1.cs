    public class HomeController 
    {
        private readonly ITenantDbContextFactory dbFactory;
        public HomeControler(ITenantDbContextFactory tenantDbContextFactory)
        {
            this.dbFactory = tenantDbContextFactory;
        }
        public void Action()
        {
            var dbContext = this.dbFactory.Create("tenantA");
            // use your context here
            dbContext...
        }
    }
