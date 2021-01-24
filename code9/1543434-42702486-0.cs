    private ObservableCollection<Item> _items = new ObservableCollection<Item>();
    public ObservableCollection<Item> Items
    {
        get { return _items; }
        set { SetProperty(ref _items, value); }
    }
