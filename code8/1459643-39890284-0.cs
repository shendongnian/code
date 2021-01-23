    Type genericType = typeof(List<>);
    Type concreteType = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => genericType.IsAssignableFrom(p)).FirstOrDefault();
    Type[] listOfTypeArgs = new[] { typeof(TabViewModel) };
    var newObject = Activator.CreateInstance(concreteType.MakeGenericType(listOfTypeArgs));
