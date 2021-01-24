    public partial class LogControl : UserControl
    {
        private readonly Queue<string> _logQueue = new Queue<string>();
        private Timer _timer;
        private bool _synced;
        public int MaxLines { get; set; } = 1000;
        public LogControl()
        {
            _timer = new Timer(state => ((LogControl)state).Refresh(), this, 1000, 1000);
            InitializeComponent();
        }
        private void Refresh()
        {
            lock (_logQueue)
            {
                if (!_synced)
                {
                    var sb = new StringBuilder();
                    foreach (var line in _logQueue)
                    {
                        sb.AppendLine(line);
                    }
                    Dispatcher.Invoke(() =>
                    {
                        TextBox.Text = sb.ToString();
                        TextBox.ScrollToEnd();
                    });
                    _synced = true;
                }
            }
        }
        public void Log(string str)
        {
            lock (_logQueue)
            {
                _logQueue.Enqueue(str);
                while (_logQueue.Count > MaxLines)
                {
                    _logQueue.Dequeue();
                }
                _synced = false;
            }
        }
        public void Clear()
        {
            lock (_logQueue)
            {
                _logQueue.Clear();
                _synced = false;
            }
        }
    }
