    using System;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfTutorialSamples.Misc
    {
            public partial class DispatcherTimerSample : Window
            {
                    public DispatcherTimerSample()
                    {
                            InitializeComponent();
                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromSeconds(1);
                            timer.Tick += timer_Tick;
                            timer.Start();
                    }
    
                    void timer_Tick(object sender, EventArgs e)
                    {
                            lblTime.Content = DateTime.Now.ToLongTimeString();
                    }
            }
    }
