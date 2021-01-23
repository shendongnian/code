        Timer Timer { get; set; }
        ToolTip toolTip { get; set; }
        public CommandButton()
        {
            InitializeComponent();
            Timer = new Timer {Interval = 3000};
            Timer.Elapsed += OnTimerElapsed;
        }
        private void CloseToolTip()
        {
            if (toolTip != null)
            {
                toolTip.IsOpen = false;
            }
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Timer.Stop();
            Application.Current.Dispatcher.BeginInvoke((Action)CloseToolTip, DispatcherPriority.Send);
        }
        private void ContentControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            toolTip = ((ToolTip)((Control)sender).ToolTip);
            toolTip.IsOpen = true;
            Timer.Start();
        }
