    public ICommand LastCommand
    {
        get
        {
            if (_lastCommand == null)
            {
                _lastCommand = new RelayCommand
                (
                    param =>
                    {
                        start = (totalItems / itemCount - 1) * itemCount;
                        start += totalItems % itemCount == 0 ? 0 : itemCount;
                        AuditTrailViewModel.Data = //Now you can update your viewModel
                        RefreshData();
                    },
                    param =>
                    {
                        return start + itemCount < totalItems ? true : false;
                    }
                );
            }
            return _lastCommand;
        }
    }
