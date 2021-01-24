    [XmlAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/")]
    public int Id { get; set; }
    [XmlAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/")]
    public int Ref { get; set; }
    private bool _nil;
    [XmlAttribute("nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public bool Nil
    {
        get
        {
            return _nil;
        }
        set
        {
            _nil = value;
        }
    }
