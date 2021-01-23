    protected override IServiceCollection ConfigureServices(IServiceCollection services)
    {
            services.AddSingleton<CSharpHelper>();
            services.AddSingleton<CSharpMigrationOperationGenerator>();
            services.AddSingleton<CSharpSnapshotGenerator>();
            services.AddSingleton<MigrationsCodeGenerator, CSharpMigrationsGenerator>();
            services.AddScaffolding();
            services.AddSingleton<CodeWriter, CustomStringBuilderCodeWriter>();
            services.AddLogging();
            return services;
        }
