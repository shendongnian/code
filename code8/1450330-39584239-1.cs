                builder.RegisterType<MyDbContextReadonly>().As<IMyDbContextReadonly>()
                    .WithParameter((pi, c) => pi.Name == "connectionString", (pi, c) => c.Resolve<IConnectionStringProvider>().ConnectionString)
                    .WithParameter("proxyCreationEnabled", false)
                    .WithParameter("lazyLoadingEnabled", false)
                    .WithParameter("autoDetectChangesEnabled", false)
                .InstancePerLifetimeScope();
