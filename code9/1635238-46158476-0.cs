    public class Product
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [PrimaryKey, AutoIncrement]
        public int ProductID { get; set; }
        [MaxLength(255)]
        public string ProductName { get; set; }
        public float Price { get; set; }
        [MaxLength(255)]
        public string Brand { get; set; }
        public string category { get; set; }
        public string ImageUrl { get; set; }
        public string description { get; set; }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // You should add ProductsRetailers class
        [ManyToMany(typeof(ProductsRetailers))]
        public List<Retailer> Retailers { get; set; }
    }
    public class Retailer
    {
        [PrimaryKey, AutoIncrement]
        public int RetailerID { get; set; }
        public string RetailerName { get; set; }
        public string RetailerAddress { get; set; }
        public string LogoUrl { get; set; }
        
        // You should add ProductsRetailers class
        [ManyToMany(typeof(ProductsRetailers))]
        public List<Product> Products { get; set; } 
    }
