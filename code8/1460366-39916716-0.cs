        class MyWrapper : IApi {
            private ClientConnection _client;
            // here you store your requests
            private Dictionary<int, PendingRequest> _pendingRequests = new Dictionary<int, PendingRequest>();
            private int _reqToken = 0;
            public MyWrapper() {
                _client = new ClientConnection(this);
            }
            public string getData(string reqdetails, TimeSpan timout) {
                // if this is multithreaded - lock over _pendingRequests when you add\remove requests there
                // and when you increment your _reqToken, or use concurrent collection
                using (var token = new PendingRequest()) {
                    var id = _reqToken;
                    // lock here
                    _pendingRequests.Add(id, token);
                    _client.request(id, reqdetails);
                    // and here use Interlocked.Increment
                    _reqToken++;
                    if (!token.Signal.WaitOne(timout)) {
                        // and here
                        _pendingRequests.Remove(id);
                        // timeout
                        throw new Exception("timout");
                    }
                    // if we are here - we have the result
                    return token.Result;
                }
            }
            public void receiveData(int reqid, string data) {
                // here you might need to lock too
                if (_pendingRequests.ContainsKey(reqid)) {                    
                    var token = _pendingRequests[reqid];
                    _pendingRequests.Remove(reqid);
                    token.Complete(data);
                }
            }
            private class PendingRequest : IDisposable {
                public PendingRequest() {
                    Signal = new ManualResetEvent(false);
                }
                public ManualResetEvent Signal { get; private set; }
                public string Result { get; private set; }
                public void Complete(string result) {
                    this.Result = result;
                    Signal.Set();
                }
                public void Dispose() {
                    Signal.Dispose();
                }
            }
        }
