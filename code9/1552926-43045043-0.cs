    public partial class MainWindow: Window   
            {  
                DispatcherTimer dispatcherTimer = new DispatcherTimer();  
                Stopwatch stopWatch= new Stopwatch();  
                string currentTime = string.Empty;  
                public MainWindow()   
                {  
                    InitializeComponent();  
                    dispatcherTimer .Tick += new EventHandler(dt_Tick);  
                    dispatcherTimer .Interval = new TimeSpan(0, 0, 0, 0, 1);  
                }  
          
                void dt_Tick(object sender, EventArgs e)   
                {  
                    if (stopWatch.IsRunning)   
                    {  
                        TimeSpan ts = sw.Elapsed;  
                        currentTime = String.Format("{0:00}:{1:00}:{2:00}",  
                        ts.Minutes, ts.Seconds, ts.Milliseconds / 10);  
                        clocktxt.Text = currentTime;  
                    }  
                }  
          
                private void startbtn_Click(object sender, RoutedEventArgs e)  
                {  
                    stopWatch.Start();  
                    dispatcherTimer .Start();  
                }  
          
                private void stopbtn_Click(object sender, RoutedEventArgs e)   
                {  
                    if (stopWatch.IsRunning)  
                    {  
                        stopWatch.Stop();  
                    }  
                    elapsedtimeitem.Items.Add(currentTime);  
                }  
          
                private void resetbtn_Click(object sender, RoutedEventArgs e)   
                {  
                    stopWatch.Reset();  
                    clocktxt.Text = "00:00:00";  
                }  
            }  
