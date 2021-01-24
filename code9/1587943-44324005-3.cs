    using System;
    using System.ComponentModel;
    using System.Timers;
    using System.Windows;
    
    namespace Test
    {
        public partial class MainWindow : Window
        {
            StopwatchManager stopwatchManager = new StopwatchManager();
            public MainWindow()
            { InitializeComponent(); }
    
            private void btnStart_Click(object sender, RoutedEventArgs e)
            { stopwatchManager.Stopwatch1.Start(); }
    
            private void btnStop_Click(object sender, RoutedEventArgs e)
            { /*SaveDuration();*/ stopwatchManager.Stopwatch1.Stop();  }
        }
    
        public class StopwatchManager
        {
            public Stopwatch Stopwatch1 { get { return _stopwatch1; } set { _stopwatch1 = value; } }
            static Stopwatch _stopwatch1 = new Stopwatch();
        }
    
        public class Stopwatch : INotifyPropertyChanged
        {
            private Timer timer = new Timer(100);
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public DateTime StartTime { get; set; } = DateTime.Now;
    
            public double Interval
            {
                get { return timer.Interval; }
                set { timer.Interval = value; }
            }
    
            public TimeSpan Duration { get { return DateTime.Now - StartTime; } }
    
            public Stopwatch()
            { timer.Elapsed += timer_Elapsed; }
    
            public void Start()
            { StartTime = DateTime.Now; timer.Start(); }
    
            public void Stop()
            { /*SaveDuration();*/ timer.Stop(); }
    
            private void timer_Elapsed(object sender, ElapsedEventArgs e)
            { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Duration")); }
        }
    }
