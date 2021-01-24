    private bool _isBusy;
            public bool IsBusy
            {
                get { return _isBusy; }
                set
                {
                    if (_isBusy != value)
                    {
                        _isBusy = value;
                        OnPropertyChanged();
                    }
                }
            }
