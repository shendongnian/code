     public string Status
            {
                get
                {
                    if (_isBusy)
                    {
                        return _localizer.Localize("Status_Busy");
                    }
                    else
                    {
                        return _localizer.Localize("Status_Free");
                    }
                }
                set
                {
                    _status = value;
                    OnPropertyChanged(); 
                }
            }
