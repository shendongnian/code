    using System.Threading.Tasks;
    public MainPage()
    {
        this.InitializeComponent();
        Loaded += async (s, e) =>
        {
            await Task.Delay(100);
            Frame.Navigate(typeof(RegionPage));
        };
    }
