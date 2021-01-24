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
            var subitem2 = new SubItem() { name = "subitem2" };
            rootitem.subItems.Add(subitem);
            rootitem.subItems.Add(subitem2);
            RootItems.Add(rootitem);
            this.DataContext = this;
        }
       
    }
    public class RootItem
    {
        public string name { get; set; }
        public List<SubItem> subItems { get; set; }
    }
    public class SubItem
    {
        public string name { get; set; }
    }
