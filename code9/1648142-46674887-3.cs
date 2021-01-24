    [XmlIgnore]
    public FlagsEnum foo{get;set;}
    public int bar
    {
        get{ return (int)foo;}
        set{ foo = (FlagsEnum)value;}
    }
