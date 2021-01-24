    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel() { Selected1 = "a", Selected2 = "d" };
        }
    }
