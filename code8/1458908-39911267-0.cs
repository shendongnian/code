    public ContainerConfiguration WithAssemblies(IEnumerable<Assembly> assemblies, AttributedModelProvider conventions)
    {
        if (assemblies == null) throw new ArgumentNullException(nameof(assemblies));
        return WithParts(assemblies.SelectMany(a => a.DefinedTypes.Select(dt => dt.AsType())), conventions);
    }
