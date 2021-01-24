    private ObservableCollection<MyItem> _myCollection = new ObservableCollection<MyItem>();
    
    public ObservableCollection<MyItem> MyCollection
    {
        get {return _myCollection;}
        set  
            {
               _myCollection = value;
               OnPropertyChanged("MyCollection");
            }
    }
