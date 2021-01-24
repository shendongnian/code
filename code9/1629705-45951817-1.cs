    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = SampleDataProvider.GetProducts();
        }
    }
