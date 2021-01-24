    services.AddConfiguration(builder =>
    {
        if (_settings.Value.UsePostgreSQL) {
            builder.UseSqlServer(_settings.Value.ConnectionString, 
                options => options.MigrationsAssembly(migrationsAssembly));
        } else {
            builder.UseNpgsql(_settings.Value.ConnectionString, 
                options => options.MigrationsAssembly(migrationsAssembly));
        }
    });
