    /// <summary>
    /// Extensions for convenience of using the request cache in views and filters.
    /// Note this is placed in the global namespace so you don't have to import it in your views.
    /// </summary>
    public static class HttpContextBaseExtensions
    {
        /// <summary>
        /// The key that is used to store your context values in the current request cache.
        /// The request cache is simply used here to transfer the cached data to the view.
        /// The difference between the request cache (HttpContext.Items) and HttpContext.Cache is that HttpContext.Items
        /// is immediately released at the end of the request. HttpContext.Cache is stored (in RAM) for the length of
        /// the timeout (or alternatively, using a sliding expiration that keeps it alive for X time after 
        /// the most recent request for it).
        /// 
        /// Note that by using a reference type
        /// this is very efficient. We aren't storing a copy of the data in the request cache, we
        /// are simply storing a pointer to the same object that exists in the cache.
        /// </summary>
        internal static string MY_DEFAULTS_KEY = "MY_DEFAULTS";
        /// <summary>
        /// This is a convenience method so we don't need to scatter the reference to the request cache key
        /// all over the application. It also makes our cache type safe.
        /// </summary>
        public static string GetMyDefault(this HttpContextBase context, string defaultKey)
        {
            // Get the defaults from the request cache.
            IDictionary<string, string> defaults = context.Items[MY_DEFAULTS_KEY] as IDictionary<string, string>;
            // Get the specific value out of the cache that was requested.
            // TryGetValue() is used to prevent an exception from being thrown if the key doesn't
            // exist. In that case, the result will be null
            string result = null;
            defaults.TryGetValue(defaultKey, out result);
            return result ?? String.Empty;
        }
        /// <summary>
        /// This is a convenience method so we don't need to scatter the reference to the request cache key
        /// all over the application. It also makes our cache type safe.
        /// </summary>
        internal static void SetMyDefaults(this HttpContextBase context, IDictionary<string, string> defaults)
        {
            context.Items[MY_DEFAULTS_KEY] = defaults;
        }
    }
