	namespace Xyz.WebLibrary
	{
		public static class Cache
		{
			// Get the value from the HttpRuntime.Cache that was stored using the cacheKey (if any). Returns true if a matching object of requested type T was found in the cache. Otherwise false is returned, along with a default(T) object or value.
			public static bool Get<T>(string cacheKey, out T result)
			{
				if (!string.IsNullOrEmpty(cacheKey))
				{
					object o = HttpRuntime.Cache.Get(cacheKey);
					if (o != null && o is T)
					{
						result = (T)o;
						return true;
					}
				}
				result = default(T);
				return false;
			}
	
			// Store a value in the HttpRuntime.Cache using the cacheKey and the specified expiration time in minutes.
			public static void Set(string cacheKey, object o, int slidingMinutes)
			{
				if (!string.IsNullOrEmpty(cacheKey) && slidingMinutes > 0)
					HttpRuntime.Cache.Insert(cacheKey, o, null, DateTime.MaxValue, TimeSpan.FromMinutes(slidingMinutes), CacheItemPriority.Normal, null);
			}
	
			// Erase the value from the HttpRuntime.Cache that was stored using the cacheKey (if any).
			public static void Erase(string cacheKey)
			{
				if (!string.IsNullOrEmpty(cacheKey) && HttpRuntime.Cache.Get(cacheKey) != null)
					HttpRuntime.Cache.Remove(cacheKey);
			}
		}
	}
