    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            this.SizeChanged += OnSizeChanged;
        }
        private Timer _timer;
        private void OnSizeChanged(object sender, SizeChangedEventArgs e) {
            // user started resizing - set large page width
            textBox.Document.PageWidth = 1000;
            // if we already setup timer - stop it and start all over
            if (_timer != null) {
                _timer.Dispose();
                _timer = null;
            }
            
            _timer = new Timer(_ => {
                // this code will run 100ms after user _stopped_ resizing
                Dispatcher.Invoke(() =>
                {
                    // reset page width back to allow wrapping algorithm to execute
                    textBox.Document.PageWidth = double.NaN;
                });
            }, null, 100, Timeout.Infinite);
        }
    }
