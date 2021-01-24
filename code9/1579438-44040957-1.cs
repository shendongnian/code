        Clock clock = new Clock();
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = clock;
            clock.InitClock();
        }
        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page1));
        }
        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page2));
        }
        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Page3));
        }
