    public string Name
    {
        get
        {
            if (_name == null)
            {
                return "none";
            }
            return _name;
        }
        set { _name = value; }
    }
