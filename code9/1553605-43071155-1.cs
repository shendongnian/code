    private ObservableCollection<Bla> _someCollection = new ObservableCollection<Bla>();
    public ObservableCollection<Bla> SomeCollection
    {
        get{ return _someCollection; }
        set
        {
            _someCollection = value;
            RaisePropertyChanged("SomeCollection");
        }
    }
