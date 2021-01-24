    public interface CommunicatorProxy : ICommunicator
    {
        private readonly Func<ICommunicator> factory;
        public CommunicatorProxy(Func<ICommunicator> factory) {
            this.factory = factory;
        }
        public Task<int> SendAsync(int c, object d) => factory().SendAsync(c, d);
        public Task<int> SendAsync(int c, IEnumerable<byte> d) => factory().SendAsync(c, d);
        public Task<T> ReceiveAsync<T>() => factory().ReceiveAsync<T>();
    }
