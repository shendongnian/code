    public partial class MainWindow : Window
    {
        private int _imgId;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Start timer to periodically change the App Icon:
            new System.Threading.Thread(() =>
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 100;
                timer.AutoReset = true;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }).Start();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {      
                //Change AppIcon on UI-Thread         
                Dispatcher.Invoke(() =>
                {
                    /* CHANGE YOUR ICONS HERE !!! */
                    BitmapSource ms_icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(Properties.Resources.Microsoft_logo.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    BitmapSource so_icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(Properties.Resources.images.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    if (_imgId == 0)
                    {
                        this.Icon = so_icon;
                        _imgId = 1;
                    }
                    else
                    {
                        this.Icon = ms_icon;
                        _imgId = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);               
            }            
        }
    }
