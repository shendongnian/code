    private RelayCommand _pinCommand;
    
    public RelayCommand pinCommand
    {
        get
        {
            if (_pinCommand == null)
            {
                _pinCommand = new RelayCommand(() =>
                {
                    //TODO:
                },
                () => true);
            }
            return _pinCommand;
        }
    }
