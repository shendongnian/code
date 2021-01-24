    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class getMetadata
    {
        private getMetadataProject projectField;
        /// <remarks/>
        public getMetadataProject Project
        {
            get
            {
                return this.projectField;
            }
            set
            {
                this.projectField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class getMetadataProject
    {
        private getMetadataProjectModule moduleField;
        private string nameField;
        /// <remarks/>
        public getMetadataProjectModule Module
        {
            get
            {
                return this.moduleField;
            }
            set
            {
                this.moduleField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class getMetadataProjectModule
    {
        private getMetadataProjectModuleAttribute[] attributesField;
        private string fullPathField;
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Attribute", IsNullable = false)]
        public getMetadataProjectModuleAttribute[] Attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FullPath
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
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class getMetadataProjectModuleAttribute
    {
        private string nameField;
        private string typeField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
