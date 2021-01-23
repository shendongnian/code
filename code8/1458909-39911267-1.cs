    // Filter out invalid exports.
    Predicate<Type> filterParts = part => !part.Equals(typeof(MockCommunicationService));
    var parts = from name in DependencyContext.Default.GetDefaultAssemblyNames()
                where name.Name.StartsWith("<<Company>>")
                let assembly = Assembly.Load(name)
                from definedType in assembly.DefinedTypes
                let part = definedType.AsType()
                where filterParts(part)
                select part;
    var configuration = new ContainerConfiguration()
        .WithParts(parts);
    return configuration.CreateContainer();
