        public MainWindow()
        {
            InitializeComponent();
            // Wait for screen to be shown before continuing...
            ContentRendered += AppLoader;
        }
        private void AppLoader(object sender, EventArgs e)
        {
            // we want to make sure this only happens once...
            ContentRendered -= AppLoader;
            // use a background worker...
            BackgroundWorker bgw = new BackgroundWorker();
            // allows us to update the status...
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            // here is where we hide the main window and continue with the application...
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            // load dll's, check security, etc.
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerAsync();
        }
        [STAThread]
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                // show main window and hide this "Splash Screen" window
                Window window = (Window)Activator.CreateInstance((Type)e.Result);
                Hide();
                window.ShowDialog();
            }
            else
                MessageBox.Show(this, "Unable to find local resources.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            Application.Current.Shutdown();
        }
        public void UpdateUI()
        {            
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Render, new DispatcherOperationCallback(delegate (object parameter)
            {
                frame.Continue = false;
                return null;
            }), null);
            Dispatcher.PushFrame(frame);
        }
        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status.Text = $"{e.UserState}";
            UpdateUI();
        }
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker Bgw = (BackgroundWorker)sender;
            e.Result = null;
            
            ConfigFile Cfg = new ConfigFile();
            if (Cfg.Count==0)
            {
                MessageBox.Show(this, "ERROR:  XmlCfg missing or not accessable.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            if (AppDLL.IsAdmin)
            {
                // load dll...
                Bgw.ReportProgress(0, "Loading...");
                e.Result = AppDLL.GetWindow("./TAC.dll", "AppWindow");
            }
            else
            {
                MessageBox.Show(this, "ERROR:  Admin credentials required.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
