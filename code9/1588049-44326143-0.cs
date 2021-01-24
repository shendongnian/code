    public ICollectionView TheICollectionView { get; set; }
    public ObservableCollection<int> OriginalList { get; set; } = new ObservableCollection<int>();
    public void Method()
    {
        TheICollectionView = new CollectionView(CollectionViewSource.GetDefaultView(OriginalList));
        ...
        OriginalList.Add(1);
    }
