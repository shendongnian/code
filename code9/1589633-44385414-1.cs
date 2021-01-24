    builder.RegisterGeneric(typeof(EfRepository<>))
           .As(typeof(IRepository<>))
           .OnPreparing(e => {
               e.Parameters = e.Parameters.Union(
                   new[] {
                       new ResolvedParameter(
                           (pi, c) => pi.ParameterType == typeof(IDbContext),
                           (pi, c) => {
                               String databaseName = 
                                   pi.Member
                                     .DeclaringType
                                     .GetGenericArguments()[0]              
                                     .GetCustomAttributes(typeof(DatabaseAttribute), true)
                                     .OfType<DatabaseAttribute>()
                                     .FirstOrDefault()
                                     .?Name
                               if (String.IsNullOrEmpty(databaseName)
                               {
                                   // TODO
                               }
                               c.ResolveNamed<IDbContext>(databaseName)
                           }
                       )
                   });
           })
           .InstancePerLifetimeScope();
