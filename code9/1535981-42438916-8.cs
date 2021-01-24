    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {
        private rootContent[] contentField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Content")]
        public rootContent[] Content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootContent
    {
        private byte uIdField;
        private string fileNameField;
        private string imageField;
        private byte[] fullPathField;
        /// <remarks/>
        public byte UId
        {
            get
            {
                return this.uIdField;
            }
            set
            {
                this.uIdField = value;
            }
        }
        /// <remarks/>
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
        /// <remarks/>
        public string Image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FullPath")]
        public byte[] FullPath
        {
            get
            {
                return this.fullPathField;
            }
            set
            {
                this.fullPathField = value;
            }
        }
    }
