    public virtual T SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }
