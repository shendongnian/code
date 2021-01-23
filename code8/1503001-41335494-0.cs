    public static void UnityContext_OnRegisterComponents(Microsoft.Practices.Unity.UnityContainer container)
    {
                                                                        , new InjectionConstructor(conf.GetSessionFactoryIntranet(AddMappingAssemblies)));
    
    
         //Repositories
         container.RegisterType<ICarRepository, CarRepository>(new HierarchicalLifetimeManager());                
    }
