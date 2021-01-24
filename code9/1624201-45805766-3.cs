    static MyEntities()
    {
        var config = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
        config.CodeFirstOptions.ColumnTypeCasingConventionCompatibility = false;
    }
