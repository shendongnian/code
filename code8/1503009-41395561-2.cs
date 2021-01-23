    using System.Collections.Concurrent;
    using System.Web.Http;
    namespace WebApplication2.Controllers
    {
        public class ValuesController : ApiController
        {
            static object _lock = new object();
            static ConcurrentDictionary<string, object> cache = new ConcurrentDictionary<string, object>();
            public object Post(InputModel value)
            {
                var existing = cache[value.Name];
                if (existing != null)
                    return new object();//Your saved record
                lock (_lock)
                {
                    existing = cache[value.Name];
                    if (existing != null)
                        return new object();//Your saved record
                    object newRecord = new object();//Save your Object
                
                    cache.AddOrUpdate(value.Name, newRecord, (s, o) => newRecord);
                    return newRecord;
                }
            }
        }
        public class InputModel
        {
            public string Name;
        }
    }
