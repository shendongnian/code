    public sealed class EntityFrameworkConfiguration : DbConfiguration
        {
            public static readonly DbConfiguration Instance = new EntityFrameworkConfiguration();
    
            EntityFrameworkConfiguration()
            {
                this.SetDefaultConnectionFactory(new OracleConnectionFactory());
                this.SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
                 this.AddInterceptor(new StringTrimmerInterceptor());
              
            }
        }
