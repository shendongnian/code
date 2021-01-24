    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.comcast.com/nationalaccountsportal/types")]
    public partial class SearchOrderResponseType : object, System.ComponentModel.INotifyPropertyChanged
    {
    
        private OrderDetails[] searchResultField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public OrderDetails[] searchResult
        {
            get
            {
                return this.searchResultField;
            }
            set
            {
                this.searchResultField = value;
                this.RaisePropertyChanged("searchResult");
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
