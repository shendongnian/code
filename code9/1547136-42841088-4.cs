    public class RequestInfo
    {
        public string Filename { get; set; }
        public int Result { get; set; }
        public int Priority { get; set; }
        internal TaskCompletionSource<int> TaskSource { get; set; }        
    }
    public class Loader : IDisposable
    {
        readonly BlockingCollection<KeyValuePair<int, RequestInfo>> _loadQueue = new BlockingCollection<KeyValuePair<int, RequestInfo>>(new ConcurrentPriorityQueue<int, RequestInfo>());
        public Loader() {
            new Thread(Loop)
            {
                IsBackground = true
            }.Start();
        }
        public Task<int> NumOfLinesinFile(string filepath, int priority) {
            RequestInfo info = new RequestInfo() {
                Filename = filepath,
                TaskSource = new TaskCompletionSource<int>(),
                Priority = priority
            };
            _loadQueue.TryAdd(new KeyValuePair<int, RequestInfo>(info.Priority, info));
            return info.TaskSource.Task;
        }
        void Loop()
        {
            foreach (var item in _loadQueue.GetConsumingEnumerable()) {
                item.Value.Result = Load(item.Value.Filename, item.Value.Priority);
                item.Value.TaskSource.SetResult(item.Value.Result);
            }                                                    
        }
        int Load(string filename, int priority)
        {
            Thread.Sleep(1000);
            return priority;
        }
        public void Dispose() {
            _loadQueue.CompleteAdding();
            _loadQueue.Dispose();
        }
    }
