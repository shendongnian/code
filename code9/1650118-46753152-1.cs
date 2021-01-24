    {
        public MainWindowView()
        {
            InitializeComponent();
            MyListBox.ItemsSource = MainWindowViewModel.Instance.Contents;
            var changeLocationWindow = new ChangeLocationWindow();
            changeLocationWindow.Show();
        }
    }
