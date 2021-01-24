    public class GenericRequestData_Type
    {
        private System.Xml.Linq.XElement[] anyField;
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.Linq.XElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
