    private List<object> _mySelectedList;
    
    public List<object> MySelectedList
    {
        get
        {
            return _mySelectedList;
        }
    
        set
        {
            _mySelectedList = value;
            this.RaisePropertyChanged("MySelectedList");
        }
    }
