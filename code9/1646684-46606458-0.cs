    private object _selectedItem;
    public object SelectedItem //because you haven't specified the type I am using an object here
    {
        get { return _selectedItem; }
        set { _selectedItem = value; OnPropertyChanged("SelectedItem"); }
    }  
