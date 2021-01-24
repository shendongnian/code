    public async void GetDescription(string name, Package package)
    {
        List<Lazy<INuGetResourceProvider>> providers = new List<Lazy<INuGetResourceProvider>>();
        providers.AddRange(Repository.Provider.GetCoreV3());  // Add v3 API support
        PackageSource packageSource = new PackageSource("https://api.nuget.org/v3/index.json");
        SourceRepository sourceRepository = new SourceRepository(packageSource, providers);
        PackageMetadataResource packageMetadataResource = await sourceRepository.GetResourceAsync<PackageMetadataResource>();
        IEnumerable<IPackageSearchMetadata> searchMetadata = await packageMetadataResource.GetMetadataAsync(name, true, true, new Logger(), CancellationToken.None);
        package.Description = searchMetadata.First().Description;
    }
