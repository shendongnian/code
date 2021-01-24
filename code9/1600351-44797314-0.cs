        public static class AutoFacRequestLog
    {
        private static object syncer = new object();
        private static List<Type> RequestedTypes { get; set; } = new List<Type>();
        public static void AddRequest(Type type)
        {
            lock (syncer)
                RequestedTypes.Add(type);
        }
        public static IEnumerable<Type> GetMostRecent(int i)
        {
            lock (syncer)
                return RequestedTypes.Skip(Math.Max(0, RequestedTypes.Count - i)).Take(i);
        }
    }
