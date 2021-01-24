    using Xceed.Wpf.Samples.SampleData;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = SampleDataProvider.GetProducts();
        }
    }
