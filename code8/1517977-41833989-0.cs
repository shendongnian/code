    [XmlIgnore]
    public TimeSpan Value 
    { 
        get 
        { 
            if(String.IsNullOrEmpty(XmlValue))
                throw new AgrumentException("Value is required.");
            return _value; 
        }
        set { _value = value; }
    } 
