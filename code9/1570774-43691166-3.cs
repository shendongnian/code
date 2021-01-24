        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = (ViewModel) DataContext;
            ViewModel.NavigateToPage += ViewModel_NavigateToPage;
        }
        private void ViewModel_NavigateToPage(object sender, Type e)
        {
            Frame.Navigate(e);
        }
