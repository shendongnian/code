    /// <summary>
    ///     Initializes the internal context, discovers and initializes sets, and initializes from a model if one is provided.
    /// </summary>
    private void InitializeLazyInternalContext(IInternalConnection internalConnection, DbCompiledModel model = null)
    {
        DbConfigurationManager.Instance.EnsureLoadedForContext(GetType());
        _internalContext = new LazyInternalContext(
                this, internalConnection, model
                , DbConfiguration.GetService<IDbModelCacheKeyFactory>()
                , DbConfiguration.GetService<AttributeProvider>());
        DiscoverAndInitializeSets();
    }
    /// <summary>
    ///     Discovers DbSets and initializes them.
    /// </summary>
    private void DiscoverAndInitializeSets()
    {
        new DbSetDiscoveryService(this).InitializeSets();
    }
