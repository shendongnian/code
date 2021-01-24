    public partial class MainWindow : Window, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> MyItems {
            get { return _items; }
            set {
                _items = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MyItems)));
            }
        }
        public MainWindow () {
            InitializeComponent();
            MyItems = new ObservableCollection<Item>();
            MyItems.Add(new Item { Key = "Key1", Value = "Value1" });
            MyItems.Add(new Item { Key = "Key2", Value = "Value2" });
            MyItems.Add(new Item { Key = "Key3", Value = "Value3" });
        }
    ....
