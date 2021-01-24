    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("OnNavigatedTo");
            base.OnNavigatedTo(e);
            this.button.Click += Button_Click;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Click -= Button_Click;
            await Task.Delay(1000); // simulate heavy load of second page
            this.Frame.Navigate(typeof(SecondPage));
        }
    }
