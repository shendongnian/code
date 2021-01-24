    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AppList
    {
        private AppListVLC[] vLCField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("VLC")]
        public AppListVLC[] VLC
        {
            get
            {
                return this.vLCField;
            }
            set
            {
                this.vLCField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AppListVLC
    {
        private string pathField;
        private string mD5GoldenHashField;
        /// <remarks/>
        public string Path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }
        /// <remarks/>
        public string MD5GoldenHash
        {
            get
            {
                return this.mD5GoldenHashField;
            }
            set
            {
                this.mD5GoldenHashField = value;
            }
        }
    }
