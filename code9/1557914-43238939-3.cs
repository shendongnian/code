    private ObservableCollection<MyData> _myData;
    private MyData _selectdItem;
    public ObservableCollection<MyData> DataCollection 
    {
        get { return _myData; }
	    set { _myData = value; OnPropertyChanged("DataCollection"); }
    }
    //Your current selected item in the datagrid
    public MyData Item
    {
        get { return _selectdItem; }
	    set
	    {
		    _selectdItem = value;
		    OnPropertyChanged("Item");
	    }
    }
    private void ReadAllItems()
    {
        foreach (var item in DataCollection)
	    {
            var mod = new Tuple<string, string>(item.Number, item.Name);
            Alist.Add(mod);
	    }
    }
    private void LoadDataCollection()
    {
        using (var db = new YourContext())
	    {
            //Your DataGrid will fill here
		    DataCollection = new ObservableCollection<MyData> ( db.YourEntity.List() )
	    }
    }
