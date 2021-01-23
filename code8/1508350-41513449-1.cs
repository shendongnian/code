    string _selectedItem;
    public string SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
        }
    }
    // RelayCommand is just a custom ICommand implementation which calls the specified delegate when the command is executed
    public RelayCommand SelectionChangedCommand
    {
        get
        {
            return new RelayCommand(unused =>
            {
                if (_selectedItem == MyItems[2])
                    _selectedItem = MyItems[0];
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            });
        }
    }
