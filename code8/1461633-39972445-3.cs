    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage ()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    
        private ObservableCollection<RootObject> collection = new ObservableCollection<RootObject>();
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                collection.Add(new RootObject
                {
                    ItemName = "Item " + i,
                    Paramether1 = "Paramether1 " + i,
                    Paramether2 = "Paramether2 " + i,
                    Paramether3 = "Paramether3 " + i,
                    Paramether4 = "Paramether4 " + i,
                    Paramether5 = "Paramether5 " + i,
                });
            }
            OrdersListView.ItemsSource = collection;
        }
    
        public ObservableCollection<string> allRoundsSelectedItem;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ObservableCollection<string> AllRoundsSelectedItem
        {
            get { return allRoundsSelectedItem; }
            set
            {
                allRoundsSelectedItem = value;
                OnPropertyChanged();
            }
        }
    
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private void OrdersListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as RootObject;
            AllRoundsSelectedItem = new ObservableCollection<string>
            {
                item.ItemName,item.Paramether1,
                item.Paramether2, item.Paramether3,
                item.Paramether4, item.Paramether5,
            };
        }
    }
