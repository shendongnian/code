    protected override IEnumerable<Assembly> ValueConverterAssemblies
    {
        get
        {
            var assemblies = base.ValueConverterAssemblies;
            var valueConverterAssemblies = assemblies as Assembly[] ?? assemblies.ToArray();
            valueConverterAssemblies.ToList().Add(typeof(ListVisibilityConverter).Assembly);
            return valueConverterAssemblies;
        }
    }
