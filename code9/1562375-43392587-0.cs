    public string Color
    {
        get
        {
            return color;
        }
        set
        {
            
            color = value;
            OnProperyChanged("Color");
        }
    }
