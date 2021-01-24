    private bool _isVisible;
            public bool IsVisible
            {
                get { return _isVisible; }
                set
                {
                    _isVisible = value;
                    OnPropertyChanged();
                }
            }
