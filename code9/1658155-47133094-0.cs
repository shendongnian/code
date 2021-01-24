    System.Data.Entity.DbConfiguration.Loaded += (_, a) =>
    {
        var services = Oracle.ManagedDataAccess.EntityFramework.EFOracleProviderServices.Instance;
        a.ReplaceService<System.Data.Entity.Core.Common.DbProviderServices>((s, k) => services);
        var factory = new Oracle.ManagedDataAccess.EntityFramework.OracleConnectionFactory();
        a.ReplaceService<System.Data.Entity.Infrastructure.IDbConnectionFactory>((s, k) => factory);
    };
