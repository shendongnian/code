    public sealed partial class GroupedItemsPage : Page
    {
        public GroupedItemsPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.Loaded += GroupedItemsPage_Loaded;
        }
        private async void GroupedItemsPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await SampleDataSource.CreateFile();
                Debug.WriteLine("Continue");
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.StackTrace);
                await msg.ShowAsync();
                throw ex.InnerException;
            }
            GlobalVars.LastFreeSignalCheckTimer.Tick += SampleDataSource.LastFreeSignalCheckTimer_Tick;
            GlobalVars.LastFreeSignalCheckTimer.Interval = new TimeSpan(0, 0, 0, 120);
            GlobalVars.LastFreeSignalCheckTimer.Start();
        }
    }
