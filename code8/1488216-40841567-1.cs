     public string Status
            {
                get
                {
                    if (_isBusy)
                    {
                        return AppResources.Status_Busy;
                    }
                    else
                    {
                        return AppResources.Status_Free;
                    }
                }
                set
                {
                    _status = value;
                    OnPropertyChanged(); 
                }
            }
