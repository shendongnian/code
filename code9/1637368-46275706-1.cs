    public sealed partial class MainPage : Page
    {
    
        ObservableCollection<Data> Products;
    
        public MainPage()
        {
            this.InitializeComponent();
            Products = new ObservableCollection<Data>()
            {
             new Data { Product = "Milk", Stock = true },
             new Data { Product = "Cheese", Stock = false },
             new Data { Product = "Bread", Stock = false },
             new Data { Product = "Chocolate", Stock = true }
            };
            this.DataContext = Products;
        }
    }
    public class Data
    {
        public string Product { get; set; }
        public bool Stock { get; set; }
    }
