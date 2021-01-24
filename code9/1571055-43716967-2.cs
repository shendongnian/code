    private ObservableCollection<Item> Items;
    
    public MainPage()
    {
        this.InitializeComponent();
        Items = new ObservableCollection<Item>();
        Items.Add(new Item());
        Items[0].Title = "Title1";
        Items.Add(new Item());
        Items[1].Title = "Title2";
        MyListView.ItemsSource = Items;
    }
    
    private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (Item item in e.RemovedItems)
        {
            item.IsSelected = false;
        }
    
        foreach (Item item in e.AddedItems)
        {
            item.IsSelected = true;
        }
    }
