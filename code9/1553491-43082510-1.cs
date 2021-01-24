        public MainPage()
        {
            this.InitializeComponent();
            frame.Navigate(typeof(APage));
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(1000);
            t.Tick += (s, e) =>
            {
                NavigatePageB();
            };
            t.Start();
        }
        private async void NavigatePageB()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
             () =>
             {
                 frame.Navigate(typeof(PageB));
             });
        }
