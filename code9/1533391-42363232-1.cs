    public partial class MainWindow : Window
    {
        public ViewModel Items { get; set; } = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
