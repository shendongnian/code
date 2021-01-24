    services.AddIdentityServer()
                    .AddTemporarySigningCredential()
                    .AddConfigurationStore(
                        builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
                    .AddOperationalStore(
                        builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
                    .AddAspNetIdentity<ApplicationUser>();
