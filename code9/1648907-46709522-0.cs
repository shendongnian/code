            var builder = new ContainerBuilder();
            builder.Register(c => new Settings()).As<ISettings>();
            builder.Register<Repository>((c) =>
                {
                    ISettings s = c.Resolve<ISettings>();
                    Settings repoSettings = User.Identity.IsAuthenticated ? s.ConfigAuth : s.Config;
                    return new Repository(repoSettings);
                }
            )
           .As<IRepository>()
           .InstancePerRequest();
            Container = builder.Build();
