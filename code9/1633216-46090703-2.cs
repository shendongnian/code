    container.RegisterTypes(AllClasses.FromAssemblies(lstAssemblyToLoad).WithMatchingInterface(),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    WithLifetime.ContainerControlled,
                                    getInjectionMembers: c => new InjectionMember[]
                                    {
                                        new Interceptor<InterfaceInterceptor>(),
                                        new InterceptionBehavior<ExceptionInterceptionBehavior>()
                                    });
