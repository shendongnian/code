    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://example.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://example.com", IsNullable = false)]
    public partial class Message
    {
    
        private Header headerField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public Header Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Header
    {
    
        private ulong senderField;
    
        private ulong receiverField;
    
        private string messageIDField;
    
        private System.DateTime creationDateTimeField;
    
        private decimal versionField;
    
        /// <remarks/>
        public ulong Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }
    
        /// <remarks/>
        public ulong Receiver
        {
            get
            {
                return this.receiverField;
            }
            set
            {
                this.receiverField = value;
            }
        }
    
        /// <remarks/>
        public string MessageID
        {
            get
            {
                return this.messageIDField;
            }
            set
            {
                this.messageIDField = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime CreationDateTime
        {
            get
            {
                return this.creationDateTimeField;
            }
            set
            {
                this.creationDateTimeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }
