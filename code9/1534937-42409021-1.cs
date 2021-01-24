    public class CachedAppSettingsLoaderSettings
    {
        public ObjectCache Cache;
        public CacheItemPolicy Policy;
        public string CacheKey;
    }
        
    public class CachedAppSettingsLoader : IAppSettingsLoader
    {
        private readonly CachedAppSettingsLoaderSettings settings;
        private readonly IAppSettingsLoader decoratee;
        public CachedAppSettingsLoader(
            CachedAppSettingsLoaderSettings settings, IAppSettingsLoader decoratee)
        {
            ...
        }
    }
