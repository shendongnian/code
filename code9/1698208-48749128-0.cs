            private void AddDatabase(IServiceCollection services)
        {
            var databaseConnectionString = Configuration.GetConnectionString("DatabseConnection");
            Check.CanConnectToDatabase(databaseConnectionString);
            services.AddDbContext<DatabaseContext>(
                options =>
                {
                    options.ConfigureWarnings(
                        warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                    options.UseSqlServer(databaseConnectionString,
                        sqlOptions => sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "SchemaName"));
                });
        }
