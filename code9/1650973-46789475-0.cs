    [XmlAnyElement("Element")]
    public XmlElement Elements{ get; set; }
    [XmlIgnore]
    public List<string> ElementNames
    {
        get
        {
            var elementNames = new List<string>();
            if (Elements != null && Elements.HasChildNodes)
            {
                elementNames.AddRange(from XmlNode elementsChildNode in Elements .ChildNodes select elementsChildNode.Name);
                return elementNames ;
            }
            else
            {
                //return empty List
                return tagNames;
            }
        }
    }
