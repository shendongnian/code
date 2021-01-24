    /// <summary>
    /// Based on a static string specified in config
    /// </summary>
    public class ConfigCacheBuster : ICacheBuster
    /// <summary>
    /// Creates a cache bust value for the lifetime of the app domain
    /// </summary>
    /// <remarks>
    /// Essentially means that all caches will be busted when the app restarts
    /// </remarks>
    public class AppDomainLifetimeCacheBuster : ICacheBuster
