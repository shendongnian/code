    public sealed partial class MainPage : Page
    {
        MyViewModel vm;
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new MyViewModel();
            DataContext = vm;
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            vm.Start();
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            vm.Stop();
        }
    }
