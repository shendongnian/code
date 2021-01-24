    container.RegisterTypes(AllClasses.FromAssemblies(lstAssemblyToLoad),
                                    WithMappings.FromAllInterfaces,
                                    WithName.TypeName,
                                    WithLifetime.ContainerControlled, 
                                    getInjectionMembers: c => new InjectionMember[]
                                    {
                                        new Interceptor<InterfaceInterceptor>(),
                                        new InterceptionBehavior<ExceptionInterceptionBehavior>()
                                    }, 
                                    overwriteExistingMappings: true);
