    public sealed class LibLogLog<T> : ILog
    {
        private static readonly ILog logger = LogProvider.For<T>();
        public bool Log(LogLevel l, Func<string> f, Exception e, params object[] p) =>
            logger.Log(l, f, e, p);
    }
