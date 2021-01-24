      public static void RegisterAllTypes(this IServiceCollection services, Assembly assembly, Type baseType,
                ServiceLifetime lifetime = ServiceLifetime.Scoped)
            {
                foreach (var type in assembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract))
                {
                    foreach (var i in type.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == baseType))
                    {
                      
                        var interfaceType = baseType.MakeGenericType(i.GetGenericArguments());
                        services.Add(new ServiceDescriptor(interfaceType, type, lifetime));
                    }
                }
            }
