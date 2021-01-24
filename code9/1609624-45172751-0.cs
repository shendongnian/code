    public class SessionData
    {
        private static readonly MemoryCache Cache = new MemoryCache("SessionData");
        private static readonly CacheItemPolicy Policy = new CacheItemPolicy {SlidingExpiration = new TimeSpan(0, 30, 0)};
        public static SessionData Get(string sessionId)
        {
            if (Cache.Contains(sessionId))
                return Cache[sessionId] as SessionData;
            var item = new SessionData {SessionId = sessionId};
            Cache.Add(sessionId, item, Policy);
            return item;
        }
        public string SessionId { get; set; }
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
