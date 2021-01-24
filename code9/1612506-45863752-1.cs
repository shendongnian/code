    Type entityType = typeof(IEntity);
    var entityTypes =   Assembly.GetAssembly(typeof(IEntity))
                        .DefinedTypes.Where(t => t.ImplementedInterfaces.Contains(entityType));
    var baseRepoType = typeof(BaseRepository<>);
    var readOnlyRepoType = typeof(ReadOnlyRepository<>);
    var baseRepoInterfaceType = typeof(IRepository<>);
    var readOnlyRepoInterfaceType = typeof(IReadOnlyRepository<>);
    var dbContextResolver = typeof(DbContextResolverHelper).GetMethod("ResolveDbContext");
    foreach (var domainType in entityTypes)
    {
      var baseRepositoryMaker = baseRepoType.MakeGenericType(domainType);
      var readonlyRepositoryMarker = readOnlyRepoType.MakeGenericType(domainType);
     var registerAsForBaseRepositoryTypes = baseRepoInterfaceType.MakeGenericType(domainType);
     var registerAsForReadOnlyRepositoryTypes = readOnlyRepoInterfaceType.MakeGenericType(domainType);
     var dbResolver = dbContextResolver.MakeGenericMethod(domainType);
                // register BaseRepository
     builder.Register(c => Activator.CreateInstance(baseRepositoryMaker, dbResolver.Invoke(null, new object[] { c }))
                ).As(registerAsForBaseRepositoryTypes).InstancePerRequest(jobTag);
                //register readonly repositories
     builder.Register(c => Activator.CreateInstance(readonlyRepositoryMarker, dbResolver.Invoke(null, new object[] { c })))
               .As(registerAsForReadOnlyRepositoryTypes).InstancePerRequest(jobTag);
    }
