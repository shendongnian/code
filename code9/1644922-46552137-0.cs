    public class SupportManagerDbConfiguration : DbConfiguration
    {
        public SupportManagerDbConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
