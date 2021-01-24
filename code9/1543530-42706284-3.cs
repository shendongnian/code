    public partial class MainWindow : Window
    {
        private ObservableCollection<MenuItem> _menuItems= new ObservableCollection<YourObj>();
    
        public MainWindow()
        {
            InitializeComponent();
            MenuItems.Add(new MenuItem{ Title = "Menu Item 1" });
            MenuItems.Add(new MenuItem{ Title = "Menu Item 2" });
        }
    
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems= value; }
        }
    }
    
    public class YourObj
    {
        public string MenuItemName{ get; set; }
    }
