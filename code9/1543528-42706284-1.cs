    public partial class MainWindow : Window
    {
        private ObservableCollection<YourObj> _menuItems= new ObservableCollection<YourObj>();
    
        public MainWindow()
        {
            InitializeComponent();
            MenuItems.Add(new YourObj{ Title = "Menu Item 1" });
            MenuItems.Add(new YourObj{ Title = "Menu Item 2" });
        }
    
        public ObservableCollection<YourObj> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems= value; }
        }
    }
    
    public class YourObj
    {
        public string MenuItemName{ get; set; }
    }
