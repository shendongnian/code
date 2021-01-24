    private string _selectedItem1;
    public string SelectedItem1
    {
        get { return _selectedItem1; }
        set
        {
            _selectedItem1 = value;
            NotifyPropertyChanged(nameof(SelectedItem1));
            NotifyPropertyChanged(nameof(List2));
            NotifyPropertyChanged(nameof(List3));
        }
    }
    // etc
