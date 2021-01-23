    public override List<IVirtualPathProvider> GetVirtualFileSources()
    {
        var existingProviders = base.GetVirtualFileSources();
        existingProviders.Add(new FileSystemMapping(this, "TEST1", "\\\\nas01\\files"));
        existingProviders.Add(new FileSystemMapping(this, "TEST2", "d:\\files"));
        return existingProviders;
    }
