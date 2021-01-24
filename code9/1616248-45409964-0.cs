    public class ReadWriteSwitchableDbSessionProxy : IDbSession
    {
        private readonly IDbSession reader;
        private readonly IDbSession writer;
        public ReadWriteSwitchableDbSessionProxy(
            IDbSession reader, IDbSession writer) { ... }
        // Session operations
        public IQueryable<T> Set<T>() => this.CurrentSession.Set<T>();
        private IDbSession CurrentSession
        {
            get
            {
                var write = (bool)HttpContext.Current.Items["WritableSession"];
                return write ? this.writer : this.reader;
            }
        }
    }
