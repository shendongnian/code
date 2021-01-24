    [XmlRoot(ElementName = "cool_element")]
    public class CoolElement
    {
        private Master masterField;
        public Master master { get { return this.masterField; } set { this.masterField = value; } }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Master
    {
        private bool visibleField; 
        private string valueField;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool visible { get { return this.visibleField; } set { this.visibleField = value; } }
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get { return this.valueField; } set { this.valueField = value; } }
    }
