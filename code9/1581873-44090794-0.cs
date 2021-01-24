    public DataTable dataTable
    {
        get { return _dataTable; }
        set
        {
            _dataTable = value;
            RaisePropertyChangedEvent("dataTable");
        }
    }
