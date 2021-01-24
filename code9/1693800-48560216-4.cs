    private string _shortDescription;
    public property string ShortDescription
    {
        get { return _shortDescription; }
        set 
        {
            if (_shortDescription == value)
            {
                return;
            }
            _shortDescription = value;
            // do other stuff
        }
    }
