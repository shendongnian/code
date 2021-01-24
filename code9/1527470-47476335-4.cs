    public ICommand ItemClickCommand
    {
        get
        {
            if (_itemClickCommand == null)
            {
                _itemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            }
            return _itemClickCommand;
        }
    }
