    public class Product
    {
        public string Value { get; set; }
    }
    public class Item
    {
        public ObservableCollection<Product> Products { get; set; }
        public Item()
        {
            Products = new ObservableCollection<Product>();
        }
    }
    public class WGen
    {
        public ObservableCollection<Item> Items { get; set; }
        public WGen()
        {
            Items = new ObservableCollection<Item>();
        }
        public void GenerateItems()
        {
            for (int i = 0; i < 5; i++)
            {
                var item = new Item();
                item.Products.Add(new Product
                {
                    Value = DateTime.Now.ToString("mm") + i.ToString()
                });
                item.Products.Add(new Product
                {
                    Value = DateTime.Now.ToString("ss") + i.ToString()
                });
                Items.Add(item);
            }
        }
    }
    
    public partial class MainWindow : Window
    {
        WGen wg;
        public MainWindow()
        {
            InitializeComponent();
            wg = new WGen();
            datagrid1.DataContext = wg;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Display()
        {
            wg.GenerateItems();
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Display();
        }
    }
