    private int _selectedIndex;
    public int SelectedIndex
    {
        get { return _selectedIndex; }
        set { _selectedIndex = value; OnPropertyChanged("SelectedIndex"); }
    }
    private FavoriteDataVm _selectedItem;
    public FavoriteDataVm SelectedItem
    {
        set
        {
            _selectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }
