    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true), System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class ModelInformation
    {
        private ModelInformationModel _modelField;
        private decimal _versionField;
        /// <remarks/>
        public ModelInformationModel Model
        {
            get
            {
                return _modelField;
            }
            set
            {
                _modelField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public decimal Version
        {
            get
            {
                return _versionField;
            }
            set
            {
                _versionField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModel
    {
        private ModelInformationModelBlock _blockField;
        /// <remarks/>
        public ModelInformationModelBlock Block
        {
            get
            {
                return _blockField;
            }
            set
            {
                _blockField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlock
    {
        private ModelInformationModelBlockP[] _pField;
        private ModelInformationModelBlockSystem _systemField;
        private string _blockTypeField;
        private string _nameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("P")]
        public ModelInformationModelBlockP[] P
        {
            get
            {
                return _pField;
            }
            set
            {
                _pField = value;
            }
        }
        /// <remarks/>
        public ModelInformationModelBlockSystem System
        {
            get
            {
                return _systemField;
            }
            set
            {
                _systemField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string BlockType
        {
            get
            {
                return _blockTypeField;
            }
            set
            {
                _blockTypeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockP
    {
        private string _nomField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Nom
        {
            get
            {
                return _nomField;
            }
            set
            {
                _nomField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystem
    {
        private ModelInformationModelBlockSystemP _pField;
        private ModelInformationModelBlockSystemBlock[] _blockField;
        /// <remarks/>
        public ModelInformationModelBlockSystemP P
        {
            get
            {
                return _pField;
            }
            set
            {
                _pField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Block")]
        public ModelInformationModelBlockSystemBlock[] Block
        {
            get
            {
                return _blockField;
            }
            set
            {
                _blockField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemP
    {
        private string _nameField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemBlock
    {
        private ModelInformationModelBlockSystemBlockP[] _pField;
        private ModelInformationModelBlockSystemBlockSystem _systemField;
        private string _blockTypeField;
        private string _nameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("P")]
        public ModelInformationModelBlockSystemBlockP[] P
        {
            get
            {
                return _pField;
            }
            set
            {
                _pField = value;
            }
        }
        /// <remarks/>
        public ModelInformationModelBlockSystemBlockSystem System
        {
            get
            {
                return _systemField;
            }
            set
            {
                _systemField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string BlockType
        {
            get
            {
                return _blockTypeField;
            }
            set
            {
                _blockTypeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemBlockP
    {
        private string _nameField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemBlockSystem
    {
        private ModelInformationModelBlockSystemBlockSystemP _pField;
        private ModelInformationModelBlockSystemBlockSystemBlock[] _blockField;
        /// <remarks/>
        public ModelInformationModelBlockSystemBlockSystemP P
        {
            get
            {
                return _pField;
            }
            set
            {
                _pField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Block")]
        public ModelInformationModelBlockSystemBlockSystemBlock[] Block
        {
            get
            {
                return _blockField;
            }
            set
            {
                _blockField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemBlockSystemP
    {
        private string _nameField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemBlockSystemBlock
    {
        private ModelInformationModelBlockSystemBlockSystemBlockP _pField;
        private string _blockTypeField;
        private string _nameField;
        /// <remarks/>
        public ModelInformationModelBlockSystemBlockSystemBlockP P
        {
            get
            {
                return _pField;
            }
            set
            {
                _pField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string BlockType
        {
            get
            {
                return _blockTypeField;
            }
            set
            {
                _blockTypeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
    }
    /// <remarks/>
    [System.Serializable(), System.ComponentModel.DesignerCategory("code"), System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class ModelInformationModelBlockSystemBlockSystemBlockP
    {
        private string _nameField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
    }
