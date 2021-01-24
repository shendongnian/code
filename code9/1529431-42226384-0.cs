        public MainWindow()
        {
            InitializeComponent();
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(delegate { }).ContinueWith(async delegate
            {
                Window win = new Window() {
                    WindowStyle =  WindowStyle.None, Topmost = true, ResizeMode = ResizeMode.NoResize, ShowInTaskbar = false, SizeToContent=  SizeToContent.WidthAndHeight,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner, Owner = this
                };
                win.Content = new LoadingAnimation();
                win.Show();
                await Task.Delay(TimeSpan.FromSeconds(4));
                win.Close();
            }, scheduler);
             
        }
