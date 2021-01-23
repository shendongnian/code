        public MainWindow()
        {
            InitializeComponent();
            tbBtn.IsChecked = true; 
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var tb = sender as ToggleButton;
            if(tb != null)
            {
                if(tb.IsChecked.HasValue && tb.IsChecked.Value)
                {
                    Debug.WriteLine("AlreadyChecked");
                }
            }
        }
