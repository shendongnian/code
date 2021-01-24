    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("form-template", Namespace = "", IsNullable = false)]
    public partial class FormTemplate
    {
        /// <remarks/>
        public Fields fields { get; set; }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Fields
    {
        /// <remarks/>
        public SingleField field { get; set; }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SingleField
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("option")]
        public Option[] option { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool required { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label { get; set; }
 
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { get; set; }
      }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Option
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool selected { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool selectedSpecified { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
