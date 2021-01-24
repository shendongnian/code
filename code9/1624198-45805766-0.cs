     public class OracleDbConfiguration : OracleEntityProviderServicesConfiguration// : DbConfiguration
        {
            public OracleDbConfiguration()
            {
                //SetDefaultConnectionFactory(new SQLiteConnectionFactory());
                //SetConfiguration(new Devart.Data.Oracle.Entity.OracleEntityProviderServicesConfiguration());
                SetProviderServices("Devart.Data.Oracle", OracleEntityProviderServices.Instance);
                //            SetProviderFactory("Devart.Data.Oracle", new OracleProviderFactory());
                SetProviderFactory("Devart.Data.Oracle", OracleProviderFactory.Instance);
                //SetProviderFactory("dotConnect for Oracle", new OracleProviderFactory());
            }
        }
