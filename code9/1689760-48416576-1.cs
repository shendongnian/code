    public bool IsAddrerssPlaceHolderVisible
            {
                get => _isAddrerssPlaceHolderVisible;
                set
                {
                    _isAddrerssPlaceHolderVisible= value;
                    RaisePropertyChanged();
                }
            }
    
    public string Address
            {
                get => _address;
                set
                {
                    _address = value;
                    if (value.Length > 0)
                    {
                        IsAddrerssPlaceHolderVisible= false;
                    }
                    else
                    {
                        IsAddrerssPlaceHolderVisible= true;
                    }
                    RaisePropertyChanged();
                }
            }
