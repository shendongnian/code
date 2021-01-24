    private bool? _viewClosed;
    public bool? ViewClosed
    {
        get { return _viewClosed; }
        set { 
                _viewClosed = value);
                RaisePropertyChanged("ViewClosed");
            }
    }
