         .AddConfigurationStore(
                         b => b.UseSqlServer(identityServerConfig.DBConfig.IdentityServer ,
                         options =>
                         {
                             options.MigrationsAssembly(migrationsAssembly);
                         }), storeOption =>
                         {
                             storeOption.DefaultSchema = "IDSVR";
                         })
