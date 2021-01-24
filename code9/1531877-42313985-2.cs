    public sealed partial class Secondary : Page
    {
        public MainPage.MyEventAggregator EventAggregator;
        public Secondary()
        {
            this.InitializeComponent();
            this.EventAggregator = new MainPage.MyEventAggregator();
        }
