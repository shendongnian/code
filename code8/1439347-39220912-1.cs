    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    
    namespace WpfTimerExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            readonly TimeSpan TIMER_DUE_TIME = TimeSpan.FromSeconds(2);
            readonly TimeSpan TIMER_PERIOD = TimeSpan.FromMilliseconds(-1);
    
            DateTimeOffset _timeWhenButtonClicked;
            DateTimeOffset _timeWhenTimerFired;
            Timer _timer;
            string _Text;
            TimeSpan _TimeDiff;
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
            public string Text
            {
                get { return _Text; }
                set { _Text = value; PropertyChanged(this, new PropertyChangedEventArgs("Text")); }
            }
            public TimeSpan TimeDiff
            {
                get { return _TimeDiff; }
                set { _TimeDiff = value; PropertyChanged(this, new PropertyChangedEventArgs("TimeDiff")); }
            }
    
            public MainWindow()
            {
                DataContext = this;
                Text = "Successfully ordered";
                InitializeComponent();
            }
            private void btnTimerExample_Click(object sender, RoutedEventArgs e)
            {
                Text = "Successfully ordered";
                TimeDiff = TimeSpan.Zero;
    
                _timeWhenButtonClicked = DateTimeOffset.UtcNow;
                // If there is no timer
                if (_timer == null) {
                    // Create and start timer. 
                    // Call TimerHandler just one time after 2 seconds
                    _timer = new Timer(TimerHandler, null, TIMER_DUE_TIME, TIMER_PERIOD);
                }
                else // if exist, just restart it
                    _timer.Change(TIMER_DUE_TIME, TIMER_PERIOD);
            }
            private void TimerHandler(object state)
            {
                _timeWhenTimerFired = DateTimeOffset.UtcNow;
                Text = "Place your chip";
                TimeDiff = _timeWhenTimerFired - _timeWhenButtonClicked;
            }
            protected override void OnClosed(EventArgs e)
            {
                if (_timer != null)
                    _timer.Dispose();
            }
        }
    }
