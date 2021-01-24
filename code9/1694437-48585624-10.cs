    public partial class MainWindow {
        private class TextBoxTraceListener : TraceListener {
            private readonly TextBoxBase _textBox;
            public TextBoxTraceListener(TextBoxBase textBox) 
                => _textBox = textBox;
            public override void WriteLine(string message) 
                => Write(message + Environment.NewLine);
            public override void Write(string message) {
                _textBox.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(() => _textBox.AppendText(message)));
            }
        }
        public MainWindow() {
            TaskScheduler.UnobservedTaskException +=
                (s, e) => Trace.TraceError(e.ToString());
            InitializeComponent();
            Trace.Listeners.Add(new TextBoxTraceListener(textBox));
            InitPort();
        }
        private async void InitPort() {
            textBox.AppendText(await ReadWriteAdapter.Current.Init());
        }
        private async void OnGetDataInSerialClick(object sender, RoutedEventArgs e) {
            textBox.Clear();
            for (var i = 0; i < 8; i++) await GetData();
        }
        private async void OnGetDataInParallelClick(object sender, RoutedEventArgs e) {
            textBox.Clear();
            await Task.WhenAll(Enumerable.Range(0, 8).Select(i => GetData()));
        }
    
        private async Task GetData() {
            await Task.Delay(50).ConfigureAwait(false); // Get off the UI thread.
            Trace.WriteLine(Encoding.ASCII.GetString(await ReadBlock.ReadParaBlock()));
        }
    }
