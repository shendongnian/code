        public MainWindow()
        {
            InitializeComponent();
            try
            {
                var resource = FindResource("ForegroundColor");
            }
            catch (ResourceReferenceKeyNotFoundException)
            {
                Resources.Add("ForegroundColor", new SolidColorBrush(Colors.Red));
            }
        }
