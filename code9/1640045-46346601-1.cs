    private string[] _items;
    public string[] Items
    {
        get { return _items; }
        set { _items = value; OnPropertyChanged("Items"); }
    }
    private List<int> _cmbList;
    public List<int> CmbList
    {
        get { return _cmbList; }
        set { _cmbList = value; OnPropertyChanged("CmbList"); }
    }
