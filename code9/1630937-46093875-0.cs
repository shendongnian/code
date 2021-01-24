    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Web;
    using System.Web.Caching;
    using Fasterflect;
    
    namespace CustomOutputCache
    {
        /// <summary>
        /// An output cache provider that has ability to modify the http header collection before a cached response is served back to the user.
        /// </summary>
        public class HeaderModOutputCacheProvider : OutputCacheProvider
        {
            private static readonly Type OutputCacheEntryType, HttpCachePolicySettingsType;
            private static readonly Type[] ParameterTypes;
    
            public static event EventHandler<CachedRequestEventArgs> RequestServedFromCache;
    
            static HeaderModOutputCacheProvider()
            {
                var systemWeb = typeof(HttpContext).Assembly;
                OutputCacheEntryType = systemWeb.GetType("System.Web.Caching.OutputCacheEntry");
                HttpCachePolicySettingsType = systemWeb.GetType("System.Web.HttpCachePolicySettings");
                ParameterTypes = new[]{
                    typeof(Guid),
                    HttpCachePolicySettingsType,
                    typeof(string),
                    typeof(string) ,
                    typeof(string[]),
                    typeof(int),
                    typeof(string),
                    typeof(List<HeaderElement>),
                    typeof(List<ResponseElement>)
                };
            }
    
            private readonly ObjectCache _objectCache;
    
            public HeaderModOutputCacheProvider()
            {
                _objectCache = new MemoryCache("output-cache");
            }
    
            #region OutputCacheProvider implementation
    
            public override object Get(string key)
            {
                var cachedValue = _objectCache.Get(key);
    
                if (cachedValue == null)
                    return null;
    
                if (cachedValue.GetType() != OutputCacheEntryType)
                    return cachedValue;
    
                var cloned = CloneOutputCacheEntry(cachedValue);
    
                if (RequestServedFromCache != null)
                {
                    var args = new CachedRequestEventArgs(cloned.HeaderElements);
                    RequestServedFromCache(this, args);
                }
    
                return cloned;
            }
    
            public override object Add(string key, object entry, DateTime utcExpiry)
            {
                _objectCache.Set(key, entry, new CacheItemPolicy { AbsoluteExpiration = utcExpiry });
                return entry;
            }
    
            public override void Set(string key, object entry, DateTime utcExpiry)
            {
                _objectCache.Set(key, entry, new CacheItemPolicy { AbsoluteExpiration = utcExpiry });
            }
    
            public override void Remove(string key)
            {
                _objectCache.Remove(key);
            }
    
            #endregion
    
            private IOutputCacheEntry CloneOutputCacheEntry(object toClone)
            {
                var parameterValues = new[]
                {
                    toClone.GetFieldValue("_cachedVaryId", Flags.InstancePrivate),
                    toClone.GetFieldValue("_settings", Flags.InstancePrivate),
                    toClone.GetFieldValue("_kernelCacheUrl", Flags.InstancePrivate),
                    toClone.GetFieldValue("_dependenciesKey", Flags.InstancePrivate),
                    toClone.GetFieldValue("_dependencies", Flags.InstancePrivate),
                    toClone.GetFieldValue("_statusCode", Flags.InstancePrivate),
                    toClone.GetFieldValue("_statusDescription", Flags.InstancePrivate),
                    CloneHeaders((List<HeaderElement>)toClone.GetFieldValue("_headerElements", Flags.InstancePrivate)),
                    toClone.GetFieldValue("_responseElements", Flags.InstancePrivate)
                };
    
                return (IOutputCacheEntry)OutputCacheEntryType.CreateInstance(
                    parameterTypes: ParameterTypes,
                    parameters: parameterValues
                );
            }
    
            private List<HeaderElement> CloneHeaders(List<HeaderElement> toClone)
            {
                return new List<HeaderElement>(toClone);
            }
        }
    
        public class CachedRequestEventArgs : EventArgs
        {
            public CachedRequestEventArgs(List<HeaderElement> headers)
            {
                Headers = headers;
            }
            public List<HeaderElement> Headers { get; private set; }
    
            public void AddCookies(HttpCookieCollection cookies)
            {
                foreach (var cookie in cookies.AllKeys.Select(c => cookies[c]))
                {
                    //more reflection unpleasantness :(
                    var header = cookie.CallMethod("GetSetCookieHeader", Flags.InstanceAnyVisibility, HttpContext.Current);
                    Headers.Add(new HeaderElement((string)header.GetPropertyValue("Name"), (string)header.GetPropertyValue("Value")));
                }
            }
        }
    }
