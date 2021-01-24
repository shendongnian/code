    public partial class MainWindow
    {     
        public MainViewModel VMMain = new MainViewModel();
        public MainWindow()
        {
            DataContext = VWMain;
            InitializeComponent();
        }
    }
