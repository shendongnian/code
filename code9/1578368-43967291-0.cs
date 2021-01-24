    private MemEntity _selectedItem;
    public MemEntity SelectedItem 
    { 
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }
