    public class OracleDbConfiguration : OracleEntityProviderServicesConfiguration// : DbConfiguration
    {
        public OracleDbConfiguration()
        {
             SetProviderServices("Devart.Data.Oracle", OracleEntityProviderServices.Instance);
             SetProviderFactory("Devart.Data.Oracle", OracleProviderFactory.Instance);
        }
    }
