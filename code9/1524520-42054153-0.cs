    private YourItemType_selectedItem;
    public YourItemType SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            if(value == _selectedItem)
                return;
    
            _selectedItem = value;
    
            NotifyOfPropertyChange("SelectedItem");
    
            // notify InfoBox property changed
           NotifyOfPropertyChange("InfoBoxItem");
        }
    }
