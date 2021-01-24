    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var product = new Product
            {
                ProductName = "Some name",
                Id = "123X",
                Size = "Big",
                OutOfStock = "true"
            };
            var itm = new ListBoxItem {Content = $"Product Name: {product.ProductName} {Environment.NewLine}" +
                                                 $"ID: {product.Id} {Environment.NewLine}" +
                                                 $"Size: {product.Size} {Environment.NewLine}" +
                                                 $"Out of stock {product.OutOfStock}"
            };
            listBox.Items.Add(itm);
        }
    }
    public class Product
    {
        public string ProductName { get; set; }
        public string Id { get; set; }
        public string Size { get; set; }
        public string OutOfStock { get; set; }
    }
