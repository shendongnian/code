    internal class Program
    {
        private static ICacheManager<object> _cache;
        private static void Main(string[] args)
        {
            _cache = CacheFactory.Build(c => c.WithDictionaryHandle());
            _cache.OnRemoveByHandle += Cache_OnRemoveByHandle;
            for (var i = 0; i < 10; i++)
            {
                _cache.Add("key" + i, "data" + i);
                AddFakeKey("key" + i);
                Thread.Sleep(1000);
            }
            Console.ReadKey();
        }
        private static void AddFakeKey(string forKey)
        {
            _cache.Add(new CacheItem<object>("trigger_" + forKey, "n/a", ExpirationMode.Absolute, TimeSpan.FromSeconds(1)));
        }
        private static void Cache_OnRemoveByHandle(object sender, CacheItemRemovedEventArgs e)
        {
            // Remark: you might get this event triggered for each level of the cache e.Level can be checked to react only on the lowest level...
            Console.WriteLine("OnRemoveByHandle " + e.ToString());
            if (e.Key.StartsWith("trigger_") && e.Reason == CacheItemRemovedReason.Expired)
            {
                var key = e.Key.Substring(8);
                Console.WriteLine("Updating key " + key);
                // updating the key
                _cache.Update(key, _ => "new value");
                // add a new fake key for another round
                AddFakeKey(key);
            }
        }
    }
