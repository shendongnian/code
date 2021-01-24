    public int ErrorsWarningsHeaderInt
    {
        get { return _overallError; }
        set
        {
            // TODO: Validation of 'value'
            _overallError = value;
            NotifyPropertyChanged(nameof(ErrorsWarningsHeader));
        }
    }
