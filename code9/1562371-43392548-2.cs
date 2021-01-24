    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            OnProperyChanged("Name");
        }
    }
    [XmlAttribute("Color")]
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
