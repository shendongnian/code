    public ICommand NextCommand
    {
        get
        {
            if (_nextCommand == null)
            {
                _nextCommand = new RelayCommand
                (
                    param =>
                    {
                        start += itemCount;
                        RefreshData();
                    },
                    param =>
                    {
                        return start + itemCount < totalItems ? true : false;
                    }
                );
            }
               return _nextCommand;
        }
    }
