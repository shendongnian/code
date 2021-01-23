    private int _myFieldA;
    private int _myFieldB;
    public int MyPropertyA
    {
        get { return _myFieldA; }
        set
        {
            _myFieldA = value;
            _myFieldB = value + 10;
            OnPropertyChanged( () => MyPropertyA );
            OnPropertyChanged( () => MyPropertyB );
        }
    }
    public int MyPropertyB
    {
        get { return _myFieldB; }
        set
        {
            _myFieldA = value - 10;
            _myFieldB = value;
            OnPropertyChanged( () => MyPropertyA );
            OnPropertyChanged( () => MyPropertyB );
        }
    }
