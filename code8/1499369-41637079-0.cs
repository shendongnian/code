    public partial class ShellView : MasterDetailPage, IMasterDetailPageOptions
    {
        public ShellView()
        {
            InitializeComponent();
        }
        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }
    }
