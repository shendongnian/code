    public class MyClass : Client, IDisposable {
        Channel channel;
        private bool _isDisposed = false;
        private readonly object _lock = new object();
        public MyClass(Channel channel)
            : base(channel) {
            this.channel = channel;
            this.channelDisposing += onDisposing;
        }
        public Channel Channel { get { return channel; } }
        private event EventHandler channelDisposing = delegate { };
        async void onDisposing(object sender, EventArgs e) {
            await channel.ShutdownAsync();
            channel = null;
        }
        public void Dispose() {
            if (!_isDisposed) {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
        void Dispose(bool disposing) {
            // No exception should ever be thrown except in critical scenarios.
            // Unhandled exceptions during finalization will tear down the process.
            if (!_isDisposed) {
                try {
                    if (disposing) {
                        // Acquire a lock on the object while disposing.
                        if (channel != null) {
                            lock (_lock) {
                                if (channel != null) {
                                    channelDisposing(this, EventArgs.Empty);
                                }
                            }
                        }
                    }
                } finally {
                    // Ensure that the flag is set
                    _isDisposed = true;
                }
            }
        }
    }
