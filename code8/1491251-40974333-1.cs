    private bool _isMeters = true;
    public bool IsMeters
    {
        get { return _isMeters; }
        set { _isMeters = value; OnPropertyChanged("IsMeters"); }
    }
    //called when I click the button to convert
    public void ConvertData(object parameter)
    {
        if (_isMeters == false)
        {
            IsMeters = true;
        }
        else
        {
            IsMeters = false;
        }
    }
