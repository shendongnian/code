    [System.Xml.Serialization.XmlArrayAttribute("Languages")]
    [System.Xml.Serialization.XmlArrayItemAttribute("Language")]
    public Language_Type[] Languages
    {
        get
        {
            return this.languagesField;
        }
        set
        {
            this.languagesField = value;
        }
    }
