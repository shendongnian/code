        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowOnLoaded;
        }
        private void MainWindowOnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindowOnLoaded;
            FillControlTree();
        }
