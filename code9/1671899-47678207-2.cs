    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }
        //  Now you can call ViewModel.GetProducts(filterString) from an event handler. 
        //  It would be more "correct" to use a Command, but let's take one step at a time. 
        public ProductViewModel ViewModel => DataContext as ProductViewModel;
    }
