    private string _Name;
    
    public string Name
    {
        get { return "[" + _Name + "]"; } // Or String.Format("[{0}]",_Name)
        set { _Name = value; }
    }
