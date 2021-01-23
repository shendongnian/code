    private int _hours;
    public int Hours
    {
        get { return _hours; }
        set 
        {
            if (value < 0 || value > 23)
                throw new ArgumentException("The value must be between 0 and 23");
            _hours = value;
        }
    }
