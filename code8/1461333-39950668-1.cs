    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel()
            {
                //Below would be replaced by an IOC container instatiation in real world(Unity, MEF etc..)
                Uc1Vm = new UC1ViewModel(),
                Uc2Vm = new UC2ViewModel()
            };
        }
    }
