    string name;
    [Browsable(false)]
    public string Name
    {
        get
        {
            if (Site != null)
                name = Site.Name;
            return name;
        }
        set
        {
            if (Site != null)
                Site.Name = value;
            name = value;
        }
    } 
