    private class CustomResolver : BaseAssemblyResolver
    {
        private DefaultAssemblyResolver _defaultResolver;
        public CustomResolver()
        {
            _defaultResolver = new DefaultAssemblyResolver();
        }
        public override AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            AssemblyDefinition assembly;
            try
            {
                assembly = _defaultResolver.Resolve(name);
            }
            catch (AssemblyResolutionException ex)
            {
                 assembly = ...; // Your resolve logic   
            }
            return assembly;
        }
    }
