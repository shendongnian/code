    using System.Collections.ObjectModel;
    static readonly ReadOnlyDictionary<string, Func<IProvider>> providerBuilderMap = new ReadOnlyDictionary<string, Func<IProvider>>(
        new Dictionary<string, Func<IProvider>>(StringComparer.OrdinalIgnoreCase)
    {
        {"firstProviderName",()=> { return new FirstProvider(); } }
    });
