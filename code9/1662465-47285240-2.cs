    private ObservableCollection<MyItem> myCollectionOfItem = new ObservableCollection<MyItem>();
    public ObservableCollection<MyItem> MyCollectionOfItem
    {
        get { return myCollectionOfItem; }
        set
        {
            myCollectionOfItem = value;
            SetPropertyChanged("MyCollectionOfItem");
        }
    }
