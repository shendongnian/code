    public override MyClass SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            //Do other stuff
        }
    }
