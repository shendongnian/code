    public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentValue = 1;
            textResult.Text = currentValue.ToString();
        }
