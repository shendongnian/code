    using System;
    using System.Timers;
    using System.Windows;
    
    namespace WpfApp3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            bool running = false; // not running
            TimeSpan updateTime = TimeSpan.FromSeconds(0.1); 
            public MainWindow()
            {
                InitializeComponent();
            }
    
            // Note that async void should only be used for event handlers
            private async void start_Click(object sender, RoutedEventArgs e)
            {
                if (!running)
                {
                    start.Content = "Stop";
    
                    var watch = StopWatch.StartNew();
                    while(running){
                        var timeSpan = watch.Elapsed;
                        var message = 
                            $"Time: {timeSpan.Hours}h {timeSpan.Minutes}m " +
                                "{timeSpan.Seconds}s {timeSpan.Milliseconds}ms";
                        lblTime.Text = message
    
                        // async sleep for a bit before updating the text again
                        await Task.Delay(updateTime);
                    }
                }
                else
                {
                    running = false;
                    start.Content = "Start";
                }
            }
        }
    }
