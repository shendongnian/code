     public partial class MainWindow: Window   
     {
        DispatcherTimer dt = new DispatcherTimer();  
        Stopwatch sw = new Stopwatch();  
        string currentTime = string.Empty;  
        public MainWindow()   
        {  
            InitializeComponent(); 
            dt.Tick += new EventHandler(dt_Tick);  
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);  
        }  
  
        void dt_Tick(object sender, EventArgs e)   
        {  
            if (sw.IsRunning)   
            {  
                TimeSpan ts = sw.Elapsed;  
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",  
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);  
                clocktxtblock.Text = currentTime;  
            }  
        }  
  
        private void startbtn_Click(object sender, RoutedEventArgs e)  
        {  
            sw.Start();  
            dt.Start();  
        }  
  
        private void stopbtn_Click(object sender, RoutedEventArgs e)   
        {  
            if (sw.IsRunning)  
            {  
                sw.Stop();  
            }  
            elapsedtimeitem.Items.Add(currentTime);  
        }  
  
        private void resetbtn_Click(object sender, RoutedEventArgs e)   
        {  
            sw.Reset();  
            clocktxtblock.Text = "00:00:00";  
        }
    }
