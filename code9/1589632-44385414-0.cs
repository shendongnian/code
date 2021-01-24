    builder.RegisterGeneric(typeof(EfRepository<>))
           .As(typeof(IRepository<>))
           .WithParameter(new ResolvedParameter(
                   (pi, c) => pi.ParameterType == typeof(IDbContext),
                   (pi, c) => c.ResolveNamed<IDbContext>(
                       pi.Member.DeclaringType
                         .GetGenericArguments()[0] 
                         .GetCustomAttributes(typeof(DatabaseAttribute), true)
                         .OfType<DatabaseAttribute>()
                         .First()
                         .Name))) 
           .InstancePerLifetimeScope();
