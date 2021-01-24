    builder.RegisterGeneric(typeof(EfRepository<>))
           .As(typeof(IRepository<>))
           .WithParameter((pi, c) => pi.ParameterType == typeof(DbContext), 
                          (pi, c) => c.ResolveNamed<DbContext>("application")); 
    builder.Register<ApplicationDbContext>()
           .Named<DbContext>("application");
