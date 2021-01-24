    private bool _isLoading;
    public bool IsLoading
    {
        get { return _isLoading; }
        set { _isLoading = value; RaisePropertyChanged(); }
    }
