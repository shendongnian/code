    public string Name
    {
        set
        {
            Utils.checkIfNull(value);
            _Name = value;
        }
    }
