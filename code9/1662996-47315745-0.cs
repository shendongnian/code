      /// <summary>Tracks instances for re-use in certain scopes.</summary>
      public class Cache : NinjectComponent, ICache, INinjectComponent, IDisposable, IPruneable
      {
        /// <summary>
        /// Contains all cached instances.
        /// This is a dictionary of scopes to a multimap for bindings to cache entries.
        /// </summary>
        private readonly IDictionary<object, Multimap<IBindingConfiguration, Cache.CacheEntry>> entries = (IDictionary<object, Multimap<IBindingConfiguration, Cache.CacheEntry>>) new Dictionary<object, Multimap<IBindingConfiguration, Cache.CacheEntry>>((IEqualityComparer<object>) new WeakReferenceEqualityComparer());
    ...
