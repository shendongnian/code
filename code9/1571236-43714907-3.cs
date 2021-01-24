    private ObservableCollection<string> Items;
    
    public MainPage()
    {
        this.InitializeComponent();
        Items = new ObservableCollection<string>();
        Items.Add("Text1");
        Items.Add("Text2");
        MyListView.ItemsSource = Items;
    }
    
    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var text = e.ClickedItem as string;
        Debug.WriteLine(text);
    }
