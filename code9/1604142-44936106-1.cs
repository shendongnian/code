    public Receipt()
    {
        Items = new ObservableCollection<Item>();
        Items.CollectionChanged += Items_CollectionChanged;
    }
    private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        Total = Items.Sum(x => x.Amount);
    }
    public ObservableCollection<Item> Items { get; set; }
