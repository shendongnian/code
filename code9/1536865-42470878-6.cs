    public interface IDbContextFactory
    {
        TestModel CreateContext();
    }
    public class DbContextFactory : IDbContextFactory
    {
        private string _siteType;
        public DbContextFactory(ISiteContext siteContext)
        {
            _siteType = siteContext.Tenant;
        }
        public TestModel CreateContext()
        {
            return new TestModel(FormatConnectionStringBySiteType(_siteType));
        }
        // or you can use this if you pass the IMultiTenantHelper dependency into your service
        public static TestModel CreateContext(string siteName)
        {
            return new TestModel(FormatConnectionStringBySiteType(siteName));
        }
        private static string FormatConnectionStringBySiteType(string siteType)
        {
            // format from web.config
            string newConnectionString = @"data source={0};initial catalog={1};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            if (siteType.Equals("a"))
            {
                return String.Format(newConnectionString, @"(LocalDb)\MSSQLLocalDB", "DbOne");
            }
            else
            {
                return String.Format(newConnectionString, @"(LocalDb)\MSSQLLocalDB", "DbTwo");
            }
        }
    }
	
