     public partial class MainWindow : Window
    {
        public ObservableCollection<RootItem> RootItems { get; set; }
       public MainWindow()
        {
            InitializeComponent();
            RootItems = new ObservableCollection<RootItem>();
            var rootitem = new RootItem() { name = "rootitem" };
            rootitem.subItems = new List<SubItem>();
            var subitem = new SubItem() { name = "subitem" };
            subitem.icon = new Image();
            subitem.icon.Source = new BitmapImage(new Uri(@"C:\Users\username\source\repos\WpfApp3\WpfApp3\New Bitmap Image.bmp"));
            var subitem2 = new SubItem() { name = "subitem2" };
            subitem2.icon = new Image();
            subitem2.icon.Source = new BitmapImage(new Uri(@"C:\Users\username\source\repos\WpfApp3\WpfApp3\New Bitmap Image.bmp"));
            rootitem.subItems.Add(subitem);
            rootitem.subItems.Add(subitem2);
            RootItems.Add(rootitem);
            this.DataContext = this;
        }
    }
    public class RootItem
    {
        public string name { get; set; }
        public Image icon { get; set; } 
        public List<SubItem> subItems { get; set; }
    }
    public class SubItem
    {
        public string name { get; set; }
        public Image icon { get; set; } 
    }
