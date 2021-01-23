    [ScriptIgnore]
    public int RealProperty { get; set; }
    
    public string RealPropertyProxy
    {
        get
        {
            return SerializeRealProperty(RealProperty);
        }
        set
        {
            RealProperty = DeserializeRealProperty(value);
        }
    }
