    public class Program
    {
        // This is a very rough snippet of the application startup piece. Its psuedo-code.
        public void Main()
        {
            var mainWindow = new MainWindow();
            
            App.Run(mainWindow);
        }
    }
    
    public class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private Window splashWindow;
        
        public MainWindow()
        {
            this.splashWindow = new SplashWindow();
            this.splashWindow.Show();
            
            this.dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.splashWindow.Close();
            this.mainWindow.Show();
        }
    }
