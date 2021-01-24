    public Data SelectedItem
    {
        get { return selectedItem; }
        set
        {
            if (value == selectedItem)
                return;
            selectedItem = value;
            RaisePropertyChanged(nameof(SelectedData)); // add this. 
        }
    }
