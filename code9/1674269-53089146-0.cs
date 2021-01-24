    // The WSDL generator doesn't properly generate the Errors Class.  This was taken from the UPS Samples.  The FaultContractAttribute was also updated to use this class instead.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ups.com/XMLSchema/XOLTWS/Error/v1.1")]
    public partial class Errors : object, System.ComponentModel.INotifyPropertyChanged
    {
        private ErrorDetailType[] errorDetailField;
        private string testElementField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ErrorDetail", Order = 0)]
        public ErrorDetailType[] ErrorDetail
        {
            get
            {
                return this.errorDetailField;
            }
            set
            {
                this.errorDetailField = value;
                this.RaisePropertyChanged("ErrorDetail");
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string TestElement
        {
            get
            {
                return this.testElementField;
            }
            set
            {
                this.testElementField = value;
                this.RaisePropertyChanged("TestElement");
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
