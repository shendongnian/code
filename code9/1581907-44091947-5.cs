    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Config
    {
        private string typeField;
        private ConfigInputs inputsField;
        /// <remarks/>
        public string Type
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
        /// <remarks/>
        public ConfigInputs Inputs
        {
            get
            {
                return this.inputsField;
            }
            set
            {
                this.inputsField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigInputs
    {
        private ConfigInputsSource_1 source_1Field;
        private ConfigInputsSource_2 source_2Field;
        private ConfigInputsSource_3 source_3Field;
        /// <remarks/>
        public ConfigInputsSource_1 Source_1
        {
            get
            {
                return this.source_1Field;
            }
            set
            {
                this.source_1Field = value;
            }
        }
        /// <remarks/>
        public ConfigInputsSource_2 Source_2
        {
            get
            {
                return this.source_2Field;
            }
            set
            {
                this.source_2Field = value;
            }
        }
        /// <remarks/>
        public ConfigInputsSource_3 Source_3
        {
            get
            {
                return this.source_3Field;
            }
            set
            {
                this.source_3Field = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigInputsSource_1
    {
        private string source_1_NameField;
        private byte source_1_InputField;
        /// <remarks/>
        public string Source_1_Name
        {
            get
            {
                return this.source_1_NameField;
            }
            set
            {
                this.source_1_NameField = value;
            }
        }
        /// <remarks/>
        public byte Source_1_Input
        {
            get
            {
                return this.source_1_InputField;
            }
            set
            {
                this.source_1_InputField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigInputsSource_2
    {
        private string source_2_NameField;
        private byte source_2_InputField;
        /// <remarks/>
        public string Source_2_Name
        {
            get
            {
                return this.source_2_NameField;
            }
            set
            {
                this.source_2_NameField = value;
            }
        }
        /// <remarks/>
        public byte Source_2_Input
        {
            get
            {
                return this.source_2_InputField;
            }
            set
            {
                this.source_2_InputField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigInputsSource_3
    {
        private string source_3_NameField;
        private byte source_3_InputField;
        /// <remarks/>
        public string Source_3_Name
        {
            get
            {
                return this.source_3_NameField;
            }
            set
            {
                this.source_3_NameField = value;
            }
        }
        /// <remarks/>
        public byte Source_3_Input
        {
            get
            {
                return this.source_3_InputField;
            }
            set
            {
                this.source_3_InputField = value;
            }
        }
    }
