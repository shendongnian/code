    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }
    }
    //  You didn't include any implementation of IEditableObject. I presume 
    //  you can add that back in to this version of the class. 
    public class Product : INotifyPropertyChanged, IEditableObject
    {
        //  You weren't raising PropertyChanged here, or anywhere at all. 
        //  In every setter on a viewmodel, you need to do that. 
        private string _title = "";
        public string Title {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged(nameof(Title));
                }
            }
        }
        public Product()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ProductViewModel : INotifyPropertyChanged
    {
        public ProductViewModel()
        {
            GetProducts("");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get { return _SelectedProduct; }
            set
            {
                if (value != _SelectedProduct)
                {
                    _SelectedProduct = value;
                    NotifyPropertyChanged(nameof(SelectedProduct));
                }
            }
        }
        public DataTable ProductsTable { get; set; }
        public void GetProducts(string filter)
        {
            //< --doing some stuff to fill the table-->
            foreach (DataRow row in ProductsTable.Rows)
            {
                Products.Add(new Product
                {
            
                    Title = (string)row["TITLE"],
            
                });
            }
        }
        private ObservableCollection<Product> _Products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products { get { return _Products; } set { _Products = value; } }
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
