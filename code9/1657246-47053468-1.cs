    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            eventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(OnMessage);
        }
        private void OnMessage(string s)
        {
            if (s == "ModulesLoaded")
            {
                //load your layout...
            }
        }
    }
