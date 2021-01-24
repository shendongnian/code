    static MyEntities()
            {
                //DbConfiguration.SetConfiguration(new Devart.Data.Oracle.Entity.OracleEntityProviderServicesConfiguration());
                var config = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
                config.CodeFirstOptions.ColumnTypeCasingConventionCompatibility = false;
            }
