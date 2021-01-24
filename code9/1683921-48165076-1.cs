    public partial class MainWindow : Window
    {
        public BindingList<Session> Sessions { get; } = new BindingList<Session>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnTest_OnClick(object sender, RoutedEventArgs e)
        {
            Sessions.Add(new Session { Title = "test1", Host = "test2" });
        }
    }
