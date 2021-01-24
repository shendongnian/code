    private Connection _connection;
    public Connection SelectedConnection
    {
        get
        {
            return _connection;
        }
        set
        {
            _connection = value;
            OnProprtyChanged();
        }
    }
