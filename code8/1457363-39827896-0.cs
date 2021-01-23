            var factoryMethod = typeof(LoggerFactoryExtensions).
                                GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).
                                First(x => x.ContainsGenericParameters);
            
            container.RegisterType(typeof(ILogger<>), new InjectionFactory((c, t, s) =>
            {
                var genFactoryMethod = factoryMethod.MakeGenericMethod(t.GetGenericArguments()[0]);
                return genFactoryMethod.Invoke(null, new object[] { loggerFactory });
            }));
