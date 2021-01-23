        public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InfoPage info = new InfoPage();
            info.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            textbox1.Text = app.commonValue;
        }
    }
