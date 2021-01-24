    public class MyCacheFilter : IActionFilter
    {
        /// <summary>
        /// The cache key that is used to store/retrieve your default values.
        /// </summary>
        private static string MY_DEFAULTS_CACHE_KEY = "MY_DEFAULTS";
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Do nothing
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cache = filterContext.HttpContext.Cache;
            // This method is called for each request. We check to ensure the cache
            // is initialized, and if not, load the values into it.
            IDictionary<string, string> defaults = 
                cache[MY_DEFAULTS_CACHE_KEY] as IDictionary<string, string>;
            if (defaults == null)
            {
                // The value doesn't exist in the cache, load it
                defaults = GetDefaults();
                // Store the defaults in the cache
                cache.Insert(
                    MY_DEFAULTS_CACHE_KEY,
                    defaults,
                    null,
                    DateTime.Now.AddHours(1), // Cache for exactly 1 hour from now
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            // Caching work is done, now return the result to the view. We can
            // do that by storing it in the request cache.
            filterContext.HttpContext.SetMyDefaults(defaults);
        }
        private IDictionary<string, string> GetDefaults()
        {
            // You weren't specific about where your defaults data is coming from
            // or even what data type it is, but you can load it from anywhere in this method
            // and return any data type. The type returned should either by readonly or thread safe.
            var defaults = new Dictionary<string, string>
            {
                { "value1", "testing" },
                { "value2", "hello world" },
                { "value3", "this works" }
            };
            // IMPORTANT: Cached data is shared throughout the application. You should make
            // sure the data structure that holds is readonly so it cannot be updated.
            // Alternatively, you could make it a thread-safe dictionary (such as ConcurrentDictionary),
            // so it can be updated and the updates will be shared between all users.
            // I am showing a readonly dictionary because it is the safest and simplest way.
            return new System.Collections.ObjectModel.ReadOnlyDictionary<string, string>(defaults);
        }
    }
