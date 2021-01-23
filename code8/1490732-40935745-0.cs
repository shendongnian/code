    public class EventLogger : IDisposable, ILogger {
        private readonly BlockingCollection<List<string>> _queue;
        private readonly Task _consumerTask;
        private FileStream _fs;
        private StreamWriter _sw;
        private System.Timers.Timer _timer;
        private object streamLock = new object();
        private const int MAX_BUFFER = 16 * 1024;      // 16K
        private const int FLUSH_INTERVAL = 10 * 1000;  // 10 seconds
        public  EventLogger() {
            OpenFile();
            _queue = new BlockingCollection<List<string>>(50);
            _consumerTask = Task.Factory.StartNew(Write, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
        void SetupFlushTimer() {
            _timer = new System.Timers.Timer(FLUSH_INTERVAL);
            _timer.AutoReset = true;
            _timer.Elapsed += TimedFlush;
        }
        void TimedFlush(Object source, System.Timers.ElapsedEventArgs e) {
            _sw?.Flush();
        }
        private void OpenFile() {
            _fs?.Dispose();
            _sw?.Dispose();
            var _logFilePath = $"D:\\Log\\log{DateTime.Now.ToString("yyyyMMdd")}{System.Diagnostics.Process.GetCurrentProcess().Id}.txt";
            _fs = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            _sw = new StreamWriter(_fs, Encoding.Default, MAX_BUFFER); // TODO: use the correct encoding here
            _sw.AutoFlush = false;
        }
        public void Dispose() {
            _timer.Elapsed -= TimedFlush;
            _timer.Dispose();
            _queue?.CompleteAdding();
            _consumerTask?.Wait();
            _sw?.Dispose();
            _fs?.Dispose();
            _queue?.Dispose();
        }
        public void Log(List<string> list) {
            try {
                _queue.TryAdd(list, 100);
            } catch (Exception e) {
                LogError(LogLevel.Error, e);
            }
        }
        private void Write() {
            foreach (List<string> items in _queue.GetConsumingEnumerable()) {
                lock (streamLock) {
                    items.ForEach(item => {
                        _sw?.WriteLine(item);
                    });
                }
            }
        }
    }
