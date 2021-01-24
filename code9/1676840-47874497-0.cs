    public class CacheObject
    {
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public CacheObject()
        {
            CreationDate = DateTime.Now;
        }
    }
    public static class CacheClass
    {
        private static Dictionary<int,CacheObject> _cache = new Dictionary<int, CacheObject>();
        public static string GetValue()
        {
            if (_cache.Count == 0 || _cache[0].CreationDate.AddMinutes(2) < DateTime.Now)
            {
                var cache = new CacheObject
                {
                    Value = GetValueFromSource()
                };
                _cache[0] = cache;
            }
            return _cache[0].Value;
        }
        public static string GetValueFromSource()
        {
            return "Jack";
        }
    }
