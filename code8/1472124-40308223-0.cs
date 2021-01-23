        public static void AddScopedFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var allServices = assembly.GetTypes().Where(p =>
                p.GetTypeInfo().IsClass &&
                !p.GetTypeInfo().IsAbstract);
            foreach (var type in allServices)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Except
                        (allInterfaces.SelectMany(t => t.GetInterfaces()));
                foreach (var itype in mainInterfaces)
                {
                    services.AddScoped(itype, type); // if you want you can pass lifetime as a parameter
                }
            }
        }
