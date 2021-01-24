    return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(t => typeof(IClass).IsAssignableFrom(t))
                    .SelectMany(t => 
                    {
                        return t.GetCustomAttributes<KeyAttribute>()
                                .Select(ka => new
                                {
                                    Key = ka,
                                    Ctor = t.GetConstructors(BindingFlags.Public).First() 
                                });
                    }) 
                    .ToDictionary(t => t.Key, t.Ctor);
