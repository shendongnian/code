    public class SqlCeDbConfiguration: DbConfiguration
    {
        public DbConfig()
        {
            SetProviderServices("System.Data.SqlServerCe.3.5", System.Data.Entity.SqlServerCompact.Legacy.SqlCeProviderServices.Instance);
        }
    }
