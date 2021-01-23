    public string Name
    {
        set
        {
            Utils u = new Utils();
            string s = value;
            u.checkIfNull(s);
            _Name = s;
        }
    }
