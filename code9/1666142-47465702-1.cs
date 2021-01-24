    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MyListViewItemsClass> Items { get; set; }
        private List<string> ItemsFromModel;
        private int _myFontSize;
        public int MyFontSize
        {
            get { return _myFontSize; }
            set
            {
                if (value != _myFontSize)
                {
                    _myFontSize = value;
                    OnPropertyChanged("MyFontSize");
                    // Font size changed, need to refresh ListView items
                    LoadRefreshMyListViewItems();
                }
            }
        }
        public MainViewModel()
        {
            // set default font size
            _myFontSize = 20;
            // example data
            ItemsFromModel = new List<string>()
        {
            "ABC",
            "ABCDEF",
            "ABCDEFGHI",
        };
            LoadRefreshMyListViewItems();
        }
        public void LoadRefreshMyListViewItems()
        {
            int itemMaxTextLength = 0;
            foreach (var modelItem in ItemsFromModel)
            {
                if (modelItem.Length > itemMaxTextLength) { itemMaxTextLength = modelItem.Length; }
            }
            Items = new ObservableCollection<MyListViewItemsClass>();
            // Convert points to pixels, multiply by max character length to determine fixed textblock width
            double width = MyFontSize * 0.75 * itemMaxTextLength;
            foreach (var itemFromModel in ItemsFromModel)
            {
                var item = new MyListViewItemsClass();
                item.MyText = itemFromModel;
                item.ItemFontSize = MyFontSize;
                item.TextWidth = width;
                Items.Add(item);
            }
            OnPropertyChanged("Items");
        }
        public class MyListViewItemsClass
        {
            public string MyText { get; set; }
            public int ItemFontSize { get; set; }
            public double TextWidth { get; set; }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
