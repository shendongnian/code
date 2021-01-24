            /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Log
        {
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute("LogRecords")]
            [System.Xml.Serialization.XmlArrayItemAttribute("LogRecord", IsNullable = false)]
            public LogRecord[] LogRecords { get; set; }
        }
