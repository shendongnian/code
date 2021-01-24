    public class NamedPipeServer {        
        public void StartAndWait() {
            
        }
        public ISubscription StartAndSubscribe() {
            // prevent race condition before Start and subscribing to MessageAvailable
            var subscription = new Subscription(this);
            StartAndWait();
            return subscription;
        }
        public ISubscription Subscribe() {
            // if user wants to subscribe and some point after start - why not
            return new Subscription(this);
        }
        public event Action<Message> MessageAvailable;
        private class Subscription : ISubscription {
            // buffer
            private readonly BlockingCollection<Message> _queue = new BlockingCollection<Message>(
                new ConcurrentQueue<Message>());
            private readonly NamedPipeServer _server;
            public Subscription(NamedPipeServer server) {
                // subscribe to event
                _server = server;
                _server.MessageAvailable += OnMessageAvailable;
            }
            public Message NextMessage(TimeSpan? timeout) {
                // this is blocking call
                if (timeout == null)
                    return _queue.Take();
                else {
                    Message tmp;
                    if (_queue.TryTake(out tmp, timeout.Value))
                        return tmp;
                    return null;
                }
            }
            private void OnMessageAvailable(Message msg) {
                // add to buffer
                _queue.Add(msg);
            }
            public void Dispose() {
                // clean up
                _server.MessageAvailable -= OnMessageAvailable;
                _queue.CompleteAdding();
                _queue.Dispose();
            }
        }
    }
