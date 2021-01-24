     //data layer
                foreach (var database in DatabaseManager.Databases)
                {
                    builder.Register<IDbContext>(c => new CodesObjectContext(database.ConnectionString))
                        .As<IDbContext>()
                        .Named<IDbContext>(database.Alias)
                        .InstancePerLifetimeScope();
                }
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
                .WithParameter(new ResolvedParameter(
                       (pi, ctx) => pi.ParameterType == typeof(IDbContext),
                       (pi, ctx) => ctx.ResolveNamed<IDbContext>(
                           (pi.Member.DeclaringType.GetGenericArguments()[0] //get generic type
                           .GetCustomAttributes(typeof(DatabaseAttribute), true)[0] as DatabaseAttribute).Name))) //get attribute database name
           .InstancePerLifetimeScope();
