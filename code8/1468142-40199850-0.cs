    public ObservableCollection<Item> itms
    {
    get{ return _itms;}
    set
    {
    if(value != _itms)
    {
    _prevItems = _itms;
    _itms = value;
    }
    
    }
