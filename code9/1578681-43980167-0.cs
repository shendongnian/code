    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReleaseDataItem obj1 = new ReleaseDataItem(false, "abc"); //passed to constructor
            ReleaseDataItem obj2 = new ReleaseDataItem(true, "xyz");
            DisplayReleaseList.Add(obj1);
            DisplayReleaseList.Add(obj2);
            ListCollectionView itemsSource = (ListCollectionView)CollectionViewSource.GetDefaultView(DisplayReleaseList);
            itemsSource.Filter = x => ((ReleaseDataItem)x).Visible;
            ReleaseDataGridView.ItemsSource = itemsSource;
        }
        public List<ReleaseDataItem> DisplayReleaseList { get; private set; } = new List<ReleaseDataItem>();
    }
    public class ReleaseDataItem
    {
        public ReleaseDataItem(bool visible, string value)
        {
            Visible = visible;
            Value = value;
        }
        public string Value { get; private set; }
        public bool Visible { get; private set; }
    }
