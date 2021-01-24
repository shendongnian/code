    return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(t => typeof(IClass).IsAssignableFrom(t))
                    .SelectMany(t => new {
                    {
                        Key = t.GetCustomAttributes(typeof(KeyAttribute), true).Cast<KeyAttribute>()),
                        Constructor = t.GetConstructors(BindingFlags.Public).First() 
                    } 
                    .ToDictionary(t => t.Key, t.Constructor);
