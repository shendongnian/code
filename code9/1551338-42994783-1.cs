    [Flags]
    public enum myFlagsEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("Flag0")]
        Zero = (1 << 0),
        [System.Xml.Serialization.XmlEnumAttribute("Flag1")]
        One = (1 << 1),
    }
