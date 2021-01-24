    private System.Collections.IEnumerable _collection;
    public System.Collections.IEnumerable MyProperty
    {
        get { return _collection; }
        set { _collection = value; OnPropertyChanged(); }
    }
